using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibCalculator;

namespace FormCalculator
{
    public partial class Form1 : Form
    {
        Calculator calc = new Calculator();

        public Form1()
        {
            InitializeComponent();
        }

        public static bool IsDouble(string value)
        {
            double num;
            bool output;

            output = double.TryParse(value, out num);
            return output;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calc.Value1 = Convert.ToDouble(valueInput1.Text);
            calc.Value2 = Convert.ToDouble(valueInput2.Text);

            calc.Add();

            valueResult.Text = Convert.ToString(calc.Result);
        }

        private void btnClearInputs_Click(object sender, EventArgs e)
        {
            valueInput1.Clear();
            valueInput2.Clear();
            valueResult.Clear();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            calc.Value1 = Convert.ToDouble(valueInput1.Text);
            calc.Value2 = Convert.ToDouble(valueInput2.Text);

            calc.Sub();

            valueResult.Text = Convert.ToString(calc.Result);
        }

        private void valueInput1_TextChanged(object sender, EventArgs e)
        {
            if (IsDouble(valueInput1.Text) == true && IsDouble(valueInput2.Text) == true)
            {
                btnAdd.Enabled = true;
                btnSubtract.Enabled = true;
                btnMulitply.Enabled = true;
                btnDivide.Enabled = true;
            } else
            {
                btnAdd.Enabled = false;
                btnSubtract.Enabled = false;
                btnMulitply.Enabled = false;
                btnDivide.Enabled = false;
            }
        }

        private void btnMulitply_Click(object sender, EventArgs e)
        {
            calc.Value1 = Convert.ToDouble(valueInput1.Text);
            calc.Value2 = Convert.ToDouble(valueInput2.Text);

            calc.Mul();

            valueResult.Text = Convert.ToString(calc.Result);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calc.Value1 = Convert.ToDouble(valueInput1.Text);
            calc.Value2 = Convert.ToDouble(valueInput2.Text);

            calc.Div();

            valueResult.Text = Convert.ToString(calc.Result);
        }
    }
}
