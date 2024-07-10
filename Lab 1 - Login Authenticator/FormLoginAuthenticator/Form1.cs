using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibLoginAuthenticator;

namespace FormLoginAuthenticator
{
    public partial class LoginAuthenticator : Form
    {
        public LoginAuthenticator()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LibLoginAuthenticator.LoginAuthenticator login = new LibLoginAuthenticator.LoginAuthenticator();

            login.username = txtUsername.Text;
            login.password = txtPassword.Text;
      
            if (string.IsNullOrEmpty (login.username)) 
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
                MessageBox.Show("Username or Password cannot be empty. Try again.");
            }
            else if (login.Authenticate() == false)
            {
                MessageBox.Show("Login Not Successful. Please try again.");
            }
            else
            {
                MessageBox.Show("Login Successful.");
                MessageBox.Show("\nThank you for using the Program\n");
                Application.Exit();
            }
        }
    }
}
