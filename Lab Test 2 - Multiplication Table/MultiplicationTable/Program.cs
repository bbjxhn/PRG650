using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Multiplication multiTable = new Multiplication();
            bool running = true;
            bool hasStarted = false;

            Console.WriteLine("Press s to start or restart Printing Multiplication Tables");
            Console.WriteLine("Press x to pause Printing Multiplication Tables");
            Console.WriteLine("Press r to restart Printing Multiplication Tables from beginning");
            Console.WriteLine("Press q to quit the application");

            while (running)
            {
                char choice = Console.ReadKey(true).KeyChar;

                switch (choice)
                {
                    case 's':
                        if (!hasStarted)
                        {
                            Console.WriteLine("\nPrinting Tables Now: ");
                            multiTable.Start();
                            hasStarted = true;
                        } 
                        else
                        {
                            Console.WriteLine("\nPrinting has been restarted");
                            multiTable.Start();
                        }
                        break;
                    case 'x':
                        Console.WriteLine("\nPrinting has been Paused: ");
                        multiTable.Pause();
                        break;
                    case 'r':
                        Console.WriteLine("\nPrinting tables from the beginning: ");
                        multiTable.Restart();
                        break;
                    case 'q':
                        multiTable.Stop();
                        Console.WriteLine("\nQuitting Application");
                        Console.WriteLine("Thread is Interrupted");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
           
        }
    }
}
