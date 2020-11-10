using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace csParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int processCost = 5000;
            int N = 100;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.For(0, N, i =>
            {
                Console.WriteLine($"Thread Id:{Thread.CurrentThread.ManagedThreadId}" +
                    $" , Now={DateTime.Now}");
                Thread.Sleep(processCost);
            });
            stopwatch.Stop();
            Console.WriteLine($"平行處理 {N} 個工作，共需 {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
