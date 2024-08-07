using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SetHostForm : Form
    {
        ProductServerHandler serverHandler = new ProductServerHandler();

        public SetHostForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text;
            string accountNumber = txtAccountNumber.Text;

            if (int.TryParse(accountNumber, out int accountNo))
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    string userName;
                    bool isConnected = serverHandler.Connect(host, accountNo, out userName);

                    // Use Invoke to update the UI from the background thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (isConnected)
                        {
                            // Connection successful, open ProductClientForm
                            ProductClientForm productClientForm = new ProductClientForm(serverHandler.GetTcpClient(), userName);
                            productClientForm.Show();
                            this.Hide(); // Hide this form
                        }
                        else
                        {
                            MessageBox.Show("Failed to connect. Please check the host and account number.");
                        }
                    });
                });
            }
            else
            {
                MessageBox.Show("Please enter a valid account number.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}