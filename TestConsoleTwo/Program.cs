using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Create and start the detached thread with a lambda expression
        Thread detachedThread = new Thread((s) =>
        {
            string value = (string)s!;

            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();

            Console.WriteLine("Detached thread: " + value + " on thread id: " + threadId);
        });
        detachedThread.Start("Hello, World!");

        string mainThreadId = Thread.CurrentThread.ManagedThreadId.ToString();

        await Console.Out.WriteLineAsync("Main thread: Hello, World!" + " on thread id: " + mainThreadId);
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

}