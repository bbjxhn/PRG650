using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class ProductClientHandler
    {
        private StreamReader reader;
        private StreamWriter writer;

        private readonly TcpClient m_tcpClient;
        private readonly ConcurrentDictionary<int, Account> m_accounts;
        private readonly List<Product> m_products;
        private readonly ConcurrentDictionary<TcpClient, Account> m_activeClients;
        private bool isConnected = false;
        private Account currentAccount = null;

        public ProductClientHandler(TcpClient tcpClient, ConcurrentDictionary<int, Account> accounts,
            List<Product> products, ConcurrentDictionary<TcpClient, Account> activeClients)
        {
            m_tcpClient = tcpClient;
            m_accounts = accounts;
            m_products = products;
            m_activeClients = activeClients;
        }

        public void Run(object threadInfo)
        {
            using (m_tcpClient)
            {
                try
                {
                    NetworkStream stream = m_tcpClient.GetStream();
                    reader = new StreamReader(stream);
                    writer = new StreamWriter(stream);

                    Console.WriteLine("Handling client connection...");

                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                            break;

                        Console.WriteLine($"Received command: {line}");

                        if (line.StartsWith("CONNECT:"))
                        {
                            HandleConnectCommand(line);
                        }
                        else if (line == "DISCONNECT")
                        {
                            HandleDisconnectCommand();
                            break;
                        }
                        else if (line == "GET_PRODUCTS")
                        {
                            HandleGetProductsCommand();
                        }
                        else if (line == "GET_ORDERS")
                        {
                            HandleGetOrdersCommand();
                        }
                        else if (line.StartsWith("PURCHASE:"))
                        {
                            HandlePurchaseCommand(line);
                        }
                        else
                        {
                            writer.WriteLine("ERROR: Unknown command");
                            writer.Flush();
                            Console.WriteLine("Unknown command received.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error handling client: {ex.Message}");
                }
            }
        }

        private void HandleConnectCommand(string line)
        {
            string[] parts = line.Split(':');
            if (parts.Length == 2 && int.TryParse(parts[1], out int accountNumber))
            {
                if (m_accounts.TryGetValue(accountNumber, out Account account))
                {
                    isConnected = true;
                    currentAccount = account;
                    m_activeClients[m_tcpClient] = account;
                    writer.WriteLine($"CONNECTED:{account.UserName}");
                    writer.Flush();
                    Console.WriteLine($"Account {accountNumber} connected as {account.UserName}.");
                }
                else
                {
                    writer.WriteLine("CONNECT_ERROR");
                    writer.Flush();
                    Console.WriteLine("Connection attempt failed: Invalid account number.");
                }
            }
            else
            {
                writer.WriteLine("CONNECT_ERROR");
                writer.Flush();
                Console.WriteLine("Connection attempt failed: Invalid account number format.");
            }
        }

        private void HandleDisconnectCommand()
        {
            if (isConnected)
            {
                m_activeClients.TryRemove(m_tcpClient, out _);
                isConnected = false;
                Console.WriteLine($"Client disconnected: {currentAccount?.UserName}");
            }
            reader?.Close();
            writer?.Close();
            m_tcpClient?.Close();
        }

        private void HandleGetProductsCommand()
        {
            if (isConnected)
            {
                try
                {
                    var productDetails = new StringBuilder("PRODUCTS:");

                    foreach (var product in m_products)
                    {
                        if (product != null && product.Quantity > 0) // Only include products with quantity > 0
                        {
                            productDetails.Append($"{product.Name},{product.Quantity}|");
                        }
                    }

                    string response = productDetails.ToString().TrimEnd('|');
                    writer.WriteLine(response);
                    writer.Flush();

                    Console.WriteLine("Sent product list to client: " + response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while sending product list: {ex.Message}");
                }
            }
            else
            {
                writer.WriteLine("NOT_CONNECTED");
                writer.Flush();
                Console.WriteLine("Client not connected. Cannot process GET_PRODUCTS.");
            }
        }

        private void HandleGetOrdersCommand()
        {
            if (isConnected)
            {
                try
                {
                    var orderDetails = new StringBuilder("ORDERS:");
                    foreach (var product in m_products)
                    {
                        if (product.PurchasedBy == currentAccount?.UserName)
                        {
                            orderDetails.Append($"{product.Name},{product.Quantity},{product.PurchasedBy}|");
                        }
                    }

                    string response = orderDetails.Length > 7 ? orderDetails.ToString().TrimEnd('|') : "ORDERS:None";
                    writer.WriteLine(response);
                    writer.Flush();

                    Console.WriteLine("Sent orders to client: " + response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while sending orders: {ex.Message}");
                }
            }
            else
            {
                writer.WriteLine("NOT_CONNECTED");
                writer.Flush();
                Console.WriteLine("Client not connected. Cannot process GET_ORDERS.");
            }
        }

        private void HandlePurchaseCommand(string line)
        {
            if (isConnected)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string[] purchaseDetails = parts[1].Split(',');
                    if (purchaseDetails.Length == 2)
                    {
                        string productName = purchaseDetails[0].Trim();
                        if (int.TryParse(purchaseDetails[1].Trim(), out int purchaseQuantity) && purchaseQuantity > 0)
                        {
                            var product = m_products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

                            if (product != null)
                            {
                                if (product.PurchasedBy == null && product.Quantity >= purchaseQuantity)
                                {
                                    product.PurchasedBy = currentAccount.UserName;
                                    product.Quantity -= purchaseQuantity;
                                    writer.WriteLine($"PURCHASED:{product.Name}");
                                    writer.Flush();
                                    Console.WriteLine($"{currentAccount.UserName} purchased {purchaseQuantity} of {product.Name}.");
                                }
                                else
                                {
                                    writer.WriteLine("NOT_AVAILABLE");
                                    writer.Flush();
                                    Console.WriteLine($"Product {product.Name} is not available in the desired quantity.");
                                }
                            }
                            else
                            {
                                writer.WriteLine("NOT_VALID");
                                writer.Flush();
                                Console.WriteLine("Purchase attempt failed: Invalid product name.");
                            }
                        }
                        else
                        {
                            writer.WriteLine("NOT_VALID");
                            writer.Flush();
                            Console.WriteLine("Purchase attempt failed: Invalid quantity format.");
                        }
                    }
                    else
                    {
                        writer.WriteLine("NOT_VALID");
                        writer.Flush();
                        Console.WriteLine("Purchase attempt failed: Invalid command format.");
                    }
                }
                else
                {
                    writer.WriteLine("NOT_VALID");
                    writer.Flush();
                    Console.WriteLine("Purchase attempt failed: Invalid command format.");
                }
            }
            else
            {
                writer.WriteLine("NOT_CONNECTED");
                writer.Flush();
                Console.WriteLine("Client not connected. Cannot process PURCHASE.");
            }
        }
    }
}
