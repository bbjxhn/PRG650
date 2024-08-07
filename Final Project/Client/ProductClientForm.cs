using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Client.ProductClientForm;

namespace Client
{
    public partial class ProductClientForm : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private string userName;
        private List<Product> products = new List<Product>();

        public ProductClientForm(TcpClient tcpClient, string userName)
        {
            InitializeComponent();
            this.client = tcpClient ?? throw new ArgumentNullException(nameof(tcpClient), "TcpClient cannot be null");
            this.userName = userName ?? throw new ArgumentNullException(nameof(userName), "UserName cannot be null");

            try
            {
                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                this.Text = $"Connected as {userName}";
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize connection: {ex.Message}");
            }
        }

        private void LoadProducts()
        {
            listBoxProducts.Items.Clear();

            try
            {
                writer.WriteLine("GET_PRODUCTS");
                writer.Flush();

                string response = reader.ReadLine();
                if (response != null && response.StartsWith("PRODUCTS:"))
                {
                    string productsData = response.Substring("PRODUCTS:".Length);
                    string[] productsArray = productsData.Split('|');

                    listBoxProducts.Items.Clear(); // Clear existing items

                    products.Clear(); // Clear existing products

                    foreach (string productData in productsArray)
                    {
                        string[] details = productData.Split(',');
                        if (details.Length == 2 && int.TryParse(details[1], out int quantity))
                        {
                            var product = new Product(details[0], quantity);
                            products.Add(product);
                            listBoxProducts.Items.Add($"{product.Name}, {product.Quantity}");
                        }
                    }
                }
                else if (response == "NOT_CONNECTED")
                {
                    MessageBox.Show("Not connected to the server.");
                }
                else
                {
                    MessageBox.Show("Failed to load products.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (listBoxProducts.SelectedItem != null)
            {
                string selectedProduct = listBoxProducts.SelectedItem.ToString();
                string[] productDetails = selectedProduct.Split(',');

                if (productDetails.Length > 0)
                {
                    string productName = productDetails[0].Trim();
                    int quantity = (int)numericUpDownQuantity.Value;  // Get the quantity from the numeric up-down control

                    try
                    {
                        writer.WriteLine($"PURCHASE:{productName},{quantity}");
                        writer.Flush();

                        string response = reader.ReadLine();
                        if (response != null && response.StartsWith("PURCHASED:"))
                        {
                            MessageBox.Show($"Successfully purchased {quantity} of {productName}.");
                            LoadProducts(); // Refresh the product list
                        }
                        else if (response == "NOT_AVAILABLE")
                        {
                            MessageBox.Show("Product is not available in the desired quantity.");
                        }
                        else if (response == "NOT_VALID")
                        {
                            MessageBox.Show("Invalid product name or quantity.");
                        }
                        else if (response == "NOT_CONNECTED")
                        {
                            MessageBox.Show("Not connected to the server.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error processing purchase: {ex.Message}");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                writer.WriteLine("DISCONNECT");
                writer.Flush();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during disconnection: {ex.Message}");
            }
            finally
            {
                Application.Exit();
            }
        }

        private void btnGetOrders_Click(object sender, EventArgs e)
        {
            try
            {
                writer.WriteLine("GET_ORDERS");
                writer.Flush();

                string response = reader.ReadLine();

                if (response != null && response.StartsWith("ORDERS:"))
                {
                    listBoxOrders.Items.Clear();

                    string ordersData = response.Substring("ORDERS:".Length);
                    if (ordersData != "None")
                    {
                        string[] ordersArray = ordersData.Split('|');

                        foreach (string orderData in ordersArray)
                        {
                            string[] details = orderData.Split(',');
                            if (details.Length >= 2)
                            {
                                string productName = details[0].Trim();
                                string quantity = details[1].Trim();
                                string purchasedBy = details.Length > 2 ? details[2].Trim() : "Unknown";

                                listBoxOrders.Items.Add($"Product: {productName}, Quantity: {quantity}, Purchased By: {purchasedBy}");
                            }
                        }
                    }
                    else
                    {
                        listBoxOrders.Items.Add("No orders found.");
                    }
                }
                else if (response == "NOT_CONNECTED")
                {
                    MessageBox.Show("Not connected to the server.");
                }
                else
                {
                    MessageBox.Show("Failed to retrieve orders.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving orders: {ex.Message}");
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
