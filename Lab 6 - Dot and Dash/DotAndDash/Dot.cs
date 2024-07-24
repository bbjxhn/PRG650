using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotAndDash
{
    internal class Dot
    {
        private readonly CancellationToken _cancellationToken;
        private readonly ManualResetEvent _manualResetEvent;

        public Dot(CancellationToken cancellationToken, ManualResetEvent manualResetEvent)
        {
            _cancellationToken = cancellationToken;
            _manualResetEvent = manualResetEvent;
        }

        public void ShowDot()
        {
            try
            {
                while (true)
                {
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Dot operation canceled.");
                        break;
                    }

                    _manualResetEvent.WaitOne(); 

                    if (_cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Dot operation canceled.");
                        break;
                    }

                    Console.Write(".");
                    Thread.Sleep(3000); 
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Dot thread was interrupted.");
            }
        }
    }
}
