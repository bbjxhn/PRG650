using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotAndDash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var mre1 = new ManualResetEvent(false);
            var mre2 = new ManualResetEvent(false);

            var dot = new Dot(cts.Token, mre1);

            var dotThread = new Thread(dot.ShowDot);
            dotThread.IsBackground = false; 
            dotThread.Start();

            var dash = new Dash();

            ThreadPool.QueueUserWorkItem(_ => dash.ShowDash((cts.Token, mre2)));

            Console.Write("Press a to set the Dot manual reset event");
            Console.Write("\nPress s to reset the Dot manual reset event");
            Console.Write("\nPress z to set the Dash manual reset event");
            Console.Write("\nPress x to reset the Dash manual reset event");
            Console.Write("\nPress q to quit\n\n");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.A)
                {
                    mre1.Set();
                    Console.WriteLine("a");
                }
                else if (key == ConsoleKey.S)
                {
                    mre1.Reset();
                    Console.WriteLine("s");
                }
                else if (key == ConsoleKey.Z)
                {
                    mre2.Set();
                    Console.WriteLine("z");
                }
                else if (key == ConsoleKey.X)
                {
                    mre2.Reset();
                    Console.WriteLine("x");
                }
                else if (key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("q");
                    Console.WriteLine("Quitting Application");
                    break;
                }
            }

            dotThread.Interrupt(); // Interrupt the dot thread
            dotThread.Join(); // Wait for the dot thread to finish
        }
    }
}
