using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    internal class Account
    {
       public int AccountNumber { get; set; }
        public string UserName { get; set; }

        public Account(int accountNumber, string userName)
        {
            AccountNumber = accountNumber;
            UserName = userName;
        }
    }
}
