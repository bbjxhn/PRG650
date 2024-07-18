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

            // Start ShowDot in a separate foreground thread
            var dotThread = new Thread(dot.ShowDot);
            dotThread.IsBackground = false; // Ensure it's a foreground thread
            dotThread.Start();

            var dash = new Dash();

            // Start ShowDash using a thread pool thread
            ThreadPool.QueueUserWorkItem(_ => dash.ShowDash((cts.Token, mre2)));

            Console.WriteLine("Press 'a' to set dot event, 's' to reset dot event, 'z' to set dash event, 'x' to reset dash event, 'q' to quit.");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.A)
                {
                    mre1.Set();
                    Console.WriteLine("Dot event set.");
                }
                else if (key == ConsoleKey.S)
                {
                    mre1.Reset();
                    Console.WriteLine("Dot event reset.");
                }
                else if (key == ConsoleKey.Z)
                {
                    mre2.Set();
                    Console.WriteLine("Dash event set.");
                }
                else if (key == ConsoleKey.X)
                {
                    mre2.Reset();
                    Console.WriteLine("Dash event reset.");
                }
                else if (key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    Console.WriteLine("Quitting...");
                    break;
                }
            }

            dotThread.Interrupt(); // Interrupt the dot thread
            dotThread.Join(); // Wait for the dot thread to finish
        }
    }
}
