using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibCalculator
{
    public class Calculator
    {
        private enum Operation
        {
            Add, Subtract, Multiply, Divide, SquareRoot, Reciprocal, None
        };

        private string displayString;
        private bool isNewValue;
        private bool hasDecimal;
        private decimal operand1;
        private decimal operand2;
        private Operation op;

        public Calculator()
        {
            displayString = string.Empty;
            isNewValue = true;
            hasDecimal = false;
            operand1 = 0;
            operand2 = 0;
            op = Operation.None;
        }

        public string DisplayString
        {
            get => displayString;
            set => displayString = value ?? "0";
        }

        public decimal displayValue
        {
            get => Convert.ToDecimal(DisplayString);
        }

        public void Append(string value)
        {
            displayString = value;
        }

        public string RemoveLast()
        {
            return displayString.Remove(DisplayString.Length - 1);
        }

        public void AddDecimalPoint()
        {
            if (!displayString.Contains("."))
            {
                displayString += ".";
            }
        }
        
        public void ToggleSign()
        {
            if (!displayString.Contains("-"))
            {
                displayString = displayString.Insert(0, "-");
            }
        }

        public void Add()
        {
            op = Operation.Add;

            operand1 = displayValue;
            isNewValue = true;
            hasDecimal = false;
        }

        public void Subtract()
        {
            op = Operation.Subtract;

            operand1 = displayValue;
            isNewValue = true;
            hasDecimal = false;
        }

        public void Multiply()
        {
            op = Operation.Multiply;

            operand1 = displayValue;
            isNewValue = true;
            hasDecimal = false;
        }

        public void Divide()
        {
            op = Operation.Divide;

            operand1 = displayValue;
            isNewValue = true;
            hasDecimal = false;
        }

        public string SquareRoot()
        {
            op = Operation.SquareRoot;
            operand1 = displayValue;
            isNewValue = true;
            hasDecimal = false;

            return displayString = Convert.ToString(Math.Sqrt((double)operand1));
        }

        public string Reciprocal()
        {
            op = Operation.Reciprocal;
            operand1 = displayValue;
            isNewValue = true;
            hasDecimal = false;
            
            return displayString = Convert.ToString(1 / operand1);
        }

        public string Equals()
        {
            if (op != Operation.None)
            {
                operand2 = displayValue;

                switch (op)
                {
                    case Operation.Add:
                        displayString = Convert.ToString(operand1 + operand2);
                        break;
                    case Operation.Subtract:
                        displayString = Convert.ToString(operand1 - operand2);
                        break;
                    case Operation.Multiply:
                        displayString = Convert.ToString(operand1 * operand2);
                        break;
                    case Operation.Divide:
                        displayString = Convert.ToString(operand1 / operand2);
                        break;
                }

                isNewValue = true;
                hasDecimal = false;
            }
            return displayString;
        }

        public void Clear()
        {
            displayString = string.Empty;
            isNewValue = true;
            hasDecimal = false;
            operand1 = 0;
            operand2 = 0;
            op = Operation.None;
        }
    }
}
