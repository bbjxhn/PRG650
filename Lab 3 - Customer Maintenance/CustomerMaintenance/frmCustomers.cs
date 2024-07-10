using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private CustomerList customers = new CustomerList();

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers.Fill();

            for (int i = 0; i < customers.Counter; i++)
            {
                lstCustomers.Items.Add(customers[i].GetDisplayText());
            }

            customers.Changed += new CustomerList.ChangeHandler(PrintToDebug);
        }

        // Event Handler
        private void PrintToDebug(CustomerList customers)
        {
            MessageBox.Show("The customer list has been changed");

            for (int i = 0; i < customers.Counter; i++)
            {
                Customer c = customers[i];
                Debug.WriteLine(c.GetDisplayText());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            frmAddCustomer addCustomerForm = new frmAddCustomer();
            Customer customer = addCustomerForm.GetNewCustomer();
            if (customer != null)
            {
                //customers.Add(customer);

                customers += customer;
                customers.Save();
                lstCustomers.Items.Add(customer.GetDisplayText());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            int i = lstCustomers.SelectedIndex;
            if (i != -1)
            {
                Customer customer = customers[i];
                string message = "Are you sure you want to delete "
                    + customer.FirstName + " " + customer.LastName + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    //customers.Remove(customer);

                    customers -= customer;
                    customers.Save();

                    lstCustomers.Items.Remove(customer.GetDisplayText());
                }
            } 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
