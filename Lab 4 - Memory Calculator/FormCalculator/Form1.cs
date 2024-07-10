using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using LibCalculator;

namespace FormCalculator
{
    public partial class Form1 : Form
    {
        Calculator calc = new Calculator();
        MemoryCalculator memory = new MemoryCalculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = calc.Equals();
            calc.Append(txtInputValue.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = null;
            calc.Add();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = null;
            calc.Subtract();
        }

        private void btnMulitply_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = null;
            calc.Multiply();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = null;
            calc.Divide();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = calc.SquareRoot();
        }

        private void btnRecip_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = calc.Reciprocal();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputValue.Clear();
            calc.Clear();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtInputValue.Text.Contains("."))
            {
                txtInputValue.Text += "."; 
            }
 
            calc.AddDecimalPoint();
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {
            txtInputValue.Text = txtInputValue.Text.Insert(0, "-");
            calc.ToggleSign();    
        }
        
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            try
            {
                txtInputValue.Text = calc.RemoveLast();
                calc.DisplayString = txtInputValue.Text;
            }
            catch { }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtInputValue.Text += "0";
            calc.Append(txtInputValue.Text);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "1";
            }
            else
            {
                txtInputValue.Text += "1";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "2";
            }
            else
            {
                txtInputValue.Text += "2";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "3";
            }
            else
            {
                txtInputValue.Text += "3";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "4";
            }
            else
            {
                txtInputValue.Text += "4";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "5";
            }
            else
            {
                txtInputValue.Text += "5";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "6";
            }
            else
            {
                txtInputValue.Text += "6";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "7";
            }
            else
            {
                txtInputValue.Text += "7";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "8";
            }
            else
            {
                txtInputValue.Text += "8";
            }
            calc.Append(txtInputValue.Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (txtInputValue.Text == "0" && txtInputValue.Text != null)
            {
                txtInputValue.Text = "9";
            }
            else
            {
                txtInputValue.Text += "9";
            }
            calc.Append(txtInputValue.Text);
        }

        // Memory Functions
        private void btnMemClear_Click(object sender, EventArgs e)
        {
            memory.MemoryClear();
            lblMemory.Text = "";
        }

        private void btnMemRecall_Click(object sender, EventArgs e)
        {
            if (memory.MemoryRecall() == 0)
            {
                MessageBox.Show("There is no number in memory.", "Memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtInputValue.Text = memory.MemoryRecall().ToString();
            }
        }

        private void btnMemStore_Click(object sender, EventArgs e)
        {
            decimal number;
            
            if (!decimal.TryParse(txtInputValue.Text, out number))
            {
                MessageBox.Show("There is no number to store in memory.", "Memory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                lblMemory.Text = "M";
                memory.MemoryStore(number);
            }
        }

        private void btnMemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtInputValue.Text = memory.MemoryAdd(calc.displayValue).ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
        private void btnFraction_Click(object sender, EventArgs e)
        {
           
        }
        
    }
}