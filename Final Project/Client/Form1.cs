using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private Button submitButton;
        private TextBox inputTextBox;
        private Label resultLabel;

        public Form1()
        {
            InitializeComponent();
            submitButton = new Button();
            inputTextBox = new TextBox();
            resultLabel = new Label();

            submitButton.Text = "Submit";
            submitButton.Click += new EventHandler(OnSubmit);

            // Layout the form controls
            submitButton.Top = 30;
            inputTextBox.Top = 0;
            resultLabel.Top = 60;

            Controls.Add(submitButton);
            Controls.Add(inputTextBox);
            Controls.Add(resultLabel);
        }

        private void OnSubmit(object sender, EventArgs e)
        {
            string input = inputTextBox.Text;
            ProductServerHandler handler = new ProductServerHandler();
            string response = handler.SendRequest(input);
            resultLabel.Text = response;
        }
    }
}
