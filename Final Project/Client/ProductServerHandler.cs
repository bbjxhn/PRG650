using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ProductServerHandler
    {
        public string SendRequest(string request)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 12345);
                NetworkStream stream = client.GetStream();

                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                stream.Write(requestBytes, 0, requestBytes.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                client.Close();
                return response;
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }
    }
}
