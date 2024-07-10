using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerMaintenance
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Customer()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
        }

        public Customer(string firstName, string lastName, string email) => (FirstName, LastName, Email) = (firstName, lastName, email);
        public string GetDisplayText() => FirstName + LastName + ", " + Email;
    }
}
