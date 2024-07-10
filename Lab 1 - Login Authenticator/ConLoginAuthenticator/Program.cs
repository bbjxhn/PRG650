using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibLoginAuthenticator;

namespace ConLoginAuthenticator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginAuthenticator login = new LoginAuthenticator();
            bool retry = true;

            do
            {
                Console.Write("\nPlease enter User Name: ");
                login.username = GetInfo();
                Console.Write("Please enter Password: ");
                login.password = GetInfo();

                if (string.IsNullOrEmpty(login.username))
                {
                    login.username = null;
                }
                else if (string.IsNullOrEmpty(login.password))
                {
                    login.password = null;
                }

                login.Authenticate();

                if (login.Authenticate() == null)
                {
                    Console.WriteLine("Username or Password cannot be empty. Try again.");
                }
                else if (login.Authenticate() == false)
                {
                    Console.WriteLine("Login Not Successful. Please try again.");
                }
                else
                {
                    Console.WriteLine("Login Successful.");
                    Console.WriteLine("\nThank you for using the Program\n");
                    retry = false;
                }
            } while (retry == true);
        }

        public static string GetInfo()
        {
            while (true)
            {
                return Console.ReadLine();
            }
        }
    }
}
