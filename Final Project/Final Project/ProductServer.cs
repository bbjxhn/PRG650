using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class ProductServer
    {
        private TcpListener _server;
        private bool _isRunning;
        private List<Product> _products;
        private Random _random;

        public ProductServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
            _isRunning = true;
            _random = new Random();
            InitializeProducts();
            Listen();
        }

        public class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }

        private void InitializeProducts()
        {
            _products = new List<Product>
        {
            new Product { Name = "Product1" },
            new Product { Name = "Product2" },
            new Product { Name = "Product3" },
            new Product { Name = "Product4" },
            new Product { Name = "Product5" }
        };

            foreach (var product in _products)
            {
                product.Quantity = _random.Next(1, 4);
            }

            Console.WriteLine("Initialized products with random quantities:");
            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Name}: {product.Quantity}");
            }
        }

        public void Listen()
        {
            while (_isRunning)
            {
                TcpClient client = _server.AcceptTcpClient();
                HandleClient(client);
            }
        }

        public void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // Display the received text on the server console
            Console.WriteLine("Received from client: " + request);

            // Process request (if needed) and prepare response
            string response = "Message received: " + request;
            byte[] responseBytes = Encoding.ASCII.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);
            client.Close();
        }
    }
}
