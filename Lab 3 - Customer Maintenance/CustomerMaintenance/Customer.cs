using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public class Customer
	{
		public Customer()
		{
		}

		public Customer(string firstName, string lastName, string email) => 
			(this.FirstName, this.LastName, this.Email) = (firstName, lastName, email);

		private string firstName;
		private string lastName;
		private string email;

		public string FirstName 
		{
			get => firstName;

			set
			{
				if (value.Length >= 30)
				{
					throw new ArgumentException("Name must be less than 30 characters");
				}
				firstName = value;
			}
		}

		public string LastName 
		{ 
			get => lastName;

			set
			{
				if (value.Length >= 30)
				{
                    throw new ArgumentException("Name must be less than 30 characters");
                }
				lastName = value;
            }
		}

		public string Email 
		{ 
			get => email;

			set
			{
				if (value.Length >= 30)
				{
                    throw new ArgumentException("Name must be less than 30 characters");
                }
				email = value;
            }
		}

		public string GetDisplayText() => FirstName + " " + LastName + ", " + Email;
	}
}
