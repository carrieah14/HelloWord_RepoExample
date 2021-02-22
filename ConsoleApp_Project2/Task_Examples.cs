using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Project2
{
    class Task_Examples
    {

        public static void TaskMethod(object o)
        {
            TaskLog(o?.ToString());
        }

        private static object Lock = new object();
        public static void TaskLog(string title)
        {
            lock (Lock)
            {
                Console.WriteLine(title);
                Console.WriteLine($"Task ID: {Task.CurrentId?.ToString() ?? "no task"}");
                Console.WriteLine($"Thread ID: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine($"Is this thread pooled? " + Thread.CurrentThread.IsThreadPoolThread);
                Console.WriteLine($"Is the thread a Background Thread? " + Thread.CurrentThread.IsBackground);
                Console.WriteLine("\n");
            }
        }

        public static void TasksUsingThreadPool()
        {
            Console.WriteLine("INSTANTIATING TASKS USING THREAD POOL:");
            // Instantiate using TaskFactory
            var factory = new TaskFactory();
            Task firstTask = factory.StartNew(TaskMethod, "Using TaskFactory");

            // Instatiated using Task class
            Task secondTask = Task.Factory.StartNew(TaskMethod, "Using Task StartNew");

            // Instantiated using a Constructor
            var thirdTask = new Task(TaskMethod, "Using Task Constructor");
            thirdTask.Start();

            // Using the Run method within Task
            Task fourthTask = Task.Run(() => TaskMethod("Using Run Method"));

            Console.WriteLine("\n");
        }

        public static void SynchronousTasks()
        {
            Console.WriteLine("RUNNING TASKS SYNCHRONOUSLY");
            TaskMethod("Main Thread:");
            var task1 = new Task(TaskMethod, "Task running synchronously to the Main Thread:");
            task1.RunSynchronously();
        }

        public static void SeperateThread()
        {
            Console.WriteLine("RUNNING TASKS ON SEPERATE THREADS");
            var task = new Task(TaskMethod, "Seperate Thread", TaskCreationOptions.LongRunning);
            task.Start();
        }
    }
}
