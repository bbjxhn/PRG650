using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    internal class ProductServerHandler
    {
        public string Hostname { get; set; } = "localhost";
        public int HostPort { get; set; } = 12345;
        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;

        public bool Connect(string host, int accountNumber, out string userName)
        {
            userName = string.Empty;
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(host, HostPort);

                NetworkStream stream = tcpClient.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                writer.WriteLine($"CONNECT:{accountNumber}");
                writer.Flush();

                string response = reader.ReadLine();
                if (response != null && response.StartsWith("CONNECTED:"))
                {
                    userName = response.Substring("CONNECTED:".Length);
                    Console.WriteLine($"Connected as {userName}");
                    return true;
                }
                else if (response == "CONNECT_ERROR")
                {
                    Console.WriteLine("Connection error: Invalid account number.");
                }
                else
                {
                    Console.WriteLine("Unexpected response: " + response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to server: {ex.Message}");
            }

            return false;
        }

        public TcpClient GetTcpClient()
        {
            return tcpClient;
        }
    }
}
