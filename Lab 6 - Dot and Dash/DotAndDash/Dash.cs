﻿using System;
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
                        break;
                    }

                    manualResetEvent.WaitOne(); 

                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    Console.Write("-");
                    Thread.Sleep(3000);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Dash thread was interrupted.");
            }
        }
    }
}
