using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMaintenance
{
    internal class CustomerList
    {
        private List<Customer> customers;

        public CustomerList()
        {
            customers = new List<Customer>();
        }

        public int Counter => customers.Count;

        public Customer this[int i] => customers[i];

        public void Add(Customer customer)
        {
            customers.Add(customer);
            //return this;

            Changed(this);
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
            //return this;

            Changed(this);
        }

        // Fills List<Customer> customers with data from "Customer.txt"
        public void Fill() => customers = CustomerDB.GetCustomers();

        // Saves List<Customer> customers to the "Customer.txt" file
        public void Save() => CustomerDB.SaveCustomers(customers);

        public static CustomerList operator +(CustomerList c1, Customer c) {
            c1.Add(c);
            return c1;
        }

        public static CustomerList operator -(CustomerList c1, Customer c)
        {
            c1.Remove(c);
            return c1;
        }

        public delegate void ChangeHandler(CustomerList customer);
        public event ChangeHandler Changed;
    }
}
