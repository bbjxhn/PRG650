using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductServer server = new ProductServer();
            server.StartServer();
        }
    }
}
