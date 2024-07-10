using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibCalculator;

namespace ConCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Welcome();
            Calculator calc = new Calculator();
            string operation, choice;
            do
            {
                Console.WriteLine("\nPlease enter first value: ");
                calc.Value1 = GetDoubleValue();
                Console.WriteLine("Please enter second value: ");
                calc.Value2 = GetDoubleValue();
                operation = GetOperator();
                Perform(calc, operation);
                Console.WriteLine("\nDo you want to do another operation? (y/n) ");
                choice = Console.ReadLine();
            } while (choice.Equals("y") || choice.Equals("Y"));
            Console.WriteLine("Thank you for using Program.");
            Console.ReadLine();
        }
    

        public static void Welcome()
        {
            Console.WriteLine("Welcome to Calculator Application.");
            Console.WriteLine("This calculator provides four operations including +, -, * and /.");
        }

        private static double GetDoubleValue()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("Invalid value. Please re-enter: ");
                }
            }
        }

        private static string GetOperator()
        {
            Console.WriteLine();
            Console.WriteLine("What operation would you like to perform? Please enter symbol.");
            Console.WriteLine("(+) for Addition");
            Console.WriteLine("(-) for Subtraction");
            Console.WriteLine("(*) for Multiplication");
            Console.WriteLine("(/) for Division\n");
            Console.Write("Please enter now: ");
            return Console.ReadLine();
        }

        public static void Perform(Calculator calc, string operation)
        {
            while (operation.Length == 0 || "+-*/".IndexOf(operation) < 0)
            {
                Console.WriteLine("Invalid Operation. Please enter again: ");
                operation = GetOperator();
            }
            switch (operation)
            {
                case "+":
                    calc.Add();
                    Console.WriteLine("The result is {0}", calc.Result);
                    break;
                case "-":
                    calc.Sub();
                    Console.WriteLine("The result is {0}", calc.Result);
                    break;
                case "*":
                    calc.Mul();
                    Console.WriteLine("The result is {0}", calc.Result);
                    break;
                case "/":
                    calc.Div();
                    Console.WriteLine("The result is {0}", calc.Result);
                    break;
            }
        }
    }
}