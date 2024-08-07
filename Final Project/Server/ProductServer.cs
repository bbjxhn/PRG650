using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class ProductServer
    {
        public IPAddress ServerIP { get; set; } = IPAddress.Any;
        public int ServerPORT { get; set; } = 12345;

        private Random random = new Random();

        private List<Product> _products;

        private void InitializeProducts()
        {
            _products = new List<Product>
            {
                new Product("Apple", random.Next(1, 4)),
                new Product("Banana", random.Next(1, 4)),
                new Product("Orange", random.Next(1, 4)),
                new Product("Grapes", random.Next(1, 4)),
                new Product("Strawberry", random.Next(1, 4))
            };

            Console.WriteLine("Initialized products with random quantities");
        }

        ConcurrentDictionary<int, Account> accounts = new ConcurrentDictionary<int, Account>()
        {
            [1111] = new Account(1111, "John"),
            [2222] = new Account(2222, "Aum"),
            [3333] = new Account(3333, "Dawei"),
        };

        private ConcurrentDictionary<TcpClient, Account> activeClients = new ConcurrentDictionary<TcpClient, Account>();

        private void Start()
        {
            InitializeProducts();

            TcpListener listener = new TcpListener(ServerIP, ServerPORT);
            listener.Start();

            while (true)
            {

                TcpClient tcpClient = listener.AcceptTcpClient();
                ProductClientHandler handler = new ProductClientHandler(tcpClient, accounts, _products, activeClients);
                ThreadPool.QueueUserWorkItem(handler.Run);
            }
        }

        public void StartServer()
        {
            new Thread(Start).Start();
            Console.WriteLine("Server started");
        }
    }
}
