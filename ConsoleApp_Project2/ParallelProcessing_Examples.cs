using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Project2
{
    class ParallelProcessing_Examples
    {
        // Examples for Parallel Class
        public static void Tasker(string step) =>
           Console.WriteLine($"{step}, task: {Task.CurrentId}, thread: {Thread.CurrentThread.ManagedThreadId}");

        public static void NormalForLoop()
        {
            Console.WriteLine("EXAMPLE OF NORMAL FOR LOOP:");
            for (int i = 0; i < 5; i++)
            {
                Tasker($"Start: {i}");
                Task.Delay(10).Wait();
                Tasker($"End: {i}");
            }

            Console.WriteLine("\n");
        }

        public static void ParallelForExample()
        {
            Console.WriteLine("EXAMPLE OF PARALLELFOR METHOD:");
            ParallelLoopResult result =
                Parallel.For(0, 10, i =>
                {
                    Tasker($"Start: {i}");
                    Task.Delay(10).Wait();
                    Tasker($"End: {i}");
                });
            Console.WriteLine("\n");
        }

        public static void ParallelForForEarly()
        {
            Console.WriteLine("EXAMPLE OF PARALLELFOR BREAK METHOD:");
            ParallelLoopResult result =
                Parallel.For(10, 20, (int i, ParallelLoopState pause) =>
                {
                    Tasker($"Star {i}");
                    if (i > 14)
                    {
                        pause.Break();
                        Console.WriteLine("Break!");
                    }
                    Task.Delay(10).Wait();
                    Tasker($"End {i}");
                });
            Console.WriteLine("\n");
        }
    }
}

