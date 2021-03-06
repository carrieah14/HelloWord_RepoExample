﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Project2
{
    class Program
    {
        static async Task Main()
        {
            await Chapter15();


            #region ParallelFor EXAMPLES
            ParallelProcessing_Examples.NormalForLoop();
            ParallelProcessing_Examples.ParallelForExample();
            ParallelProcessing_Examples.ParallelForForEarly();
            #endregion

            #region TASK EXAMPLES
            Task_Examples.TasksUsingThreadPool();
            Task_Examples.SynchronousTasks();
            Task_Examples.SeperateThread();
            #endregion

        }

        static async Task Chapter15() 
        { 
            Console.WriteLine("Hello World!");
            Stopwatch timer = new Stopwatch();
            
            timer.Start();
            Console.WriteLine("Timer Start");

            Task task1 = Method1();
            Task task2 = Method2();
            Task task3 = Method3();

            await Task.WhenAll(task1, task2, task3);

            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime: " + elapsedTime);

        }

        static async Task Method1()
        {
            await Task.Delay(10000);
        }

        static async Task Method2()
        {
            await Task.Delay(10000); 
        }
        static async Task Method3()
        {
            await Task.Delay(10000);
        }

    }
}
