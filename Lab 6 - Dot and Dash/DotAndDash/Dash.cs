using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotAndDash
{
    internal class Dash
    {
        public void ShowDash((CancellationToken cancellationToken, ManualResetEvent manualResetEvent) parameters)
        {
            var (cancellationToken, manualResetEvent) = parameters;

            try
            {
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Dash operation canceled.");
                        break;
                    }

                    manualResetEvent.WaitOne(); // Wait indefinitely for the event to be set

                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Dash operation canceled.");
                        break;
                    }

                    Console.Write("-");
                    Thread.Sleep(3000); // Sleep for 3 seconds
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Dash thread was interrupted.");
            }
        }
    }
}
