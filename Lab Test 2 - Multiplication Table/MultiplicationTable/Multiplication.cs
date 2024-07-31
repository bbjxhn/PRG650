using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiplicationTable
{
    internal class Multiplication
    {
        private int currentNum;
        private Thread thread;
        private CancellationTokenSource cancellationTokenSource;
        private ManualResetEventSlim pauseEvent;

        public Multiplication()
        {
            currentNum = 1;
            cancellationTokenSource = new CancellationTokenSource();
            pauseEvent = new ManualResetEventSlim(true);
        }

        public void GenerateTables()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                pauseEvent.Wait();

                Console.Write($"\nMultiplication Table of {currentNum} is:");

                for (int i = 1; i <= 10; i++)
                {
                    Console.Write($"  {currentNum * i}");
                }

                currentNum++;
                Thread.Sleep(1000);
            }
        }

        public void Start()
        {
            if (thread == null || !thread.IsAlive)
            {
                thread = new Thread(GenerateTables);
                thread.Start();
            } else
            {
                pauseEvent.Set();
            }
        }

        public void Pause()
        {
            pauseEvent.Reset();
        }

        public void Restart()
        {
            currentNum = 1;
            pauseEvent.Set(); 
        }
    

        public void Stop()
        {
            cancellationTokenSource.Cancel();
            pauseEvent.Set();

            if (thread != null && thread.IsAlive)
            {
                thread.Join();
            }
        }
    }
}
