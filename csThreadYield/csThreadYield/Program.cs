using System;
using System.Threading;

namespace csThreadYield
{
    class Program
    {
        static int counter = 0;
        static int Max = 100;
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < Max; i++)
                {
                    counter++;
                    Thread.Yield();
                }
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < Max; i++)
                {
                    counter--;
                    Thread.Yield();
                }
            });

            thread1.Start(); thread2.Start();
            thread1.Join();thread2.Join();
            Console.WriteLine($"Counter={counter}");
        }
    }
}
