using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {
        List<Customer> customers = null;
        Customer newCustomer = new Customer();

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers();
            lstCustomers.Items.Add(newCustomer.GetDisplayText());

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer add_customer = new frmAddCustomer();
            add_customer.GetNewCustomer();

            if (add_customer.GetNewCustomer() != null)
            {
                customers.Add(add_customer.GetNewCustomer());
                CustomerDB.SaveCustomers(customers);

            }
            Refresh();
        }
    }
}
