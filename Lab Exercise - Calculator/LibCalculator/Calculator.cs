using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCalculator
{
    public class Calculator
    {
        private double value1;
        private double value2;
        private double result;
        public Calculator()
        {
            value1 = 0;
            value2 = 0;
            result = 0;
        }
        public double Value1
        {
            get { return value1; }
            set { value1 = value; }
        }
        public double Value2
        {
            get { return value2; }
            set { value2 = value; }
        }

        public double Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Add()
        {
            result = value1 + value2;
        }
        public void Sub()
        {
            result = value1 - value2;
        }
        public void Mul()
        {
            result = value1 * value2;
        }
        public void Div()
        {
            result = value2 == 0 ? 0 : value1 / value2;
        }
    }
}
