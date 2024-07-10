using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        public Customer customer = null;

        public frmAddCustomer()
        {
            InitializeComponent();
        }

        public Customer GetNewCustomer()
        {
            this.ShowDialog();
            return customer;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            errorMessage += Validator.IsPresent(txtFirstName.Text, txtFirstName.Tag.ToString());
            errorMessage += Validator.IsPresent(txtLastName.Text, txtLastName.Tag.ToString());
            errorMessage += Validator.IsValidEmail(txtEmail.Text, txtEmail.Tag.ToString());

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, "Entry Error");
            }
            customer = new Customer(txtFirstName.Text, txtLastName.Text, txtEmail.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
