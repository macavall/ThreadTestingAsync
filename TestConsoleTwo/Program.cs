using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Declare an event delegate
    public delegate void MyEventHandler(object sender, EventArgs e);

    // Declare the event
    public static event MyEventHandler MyEvent;

    static async Task Main() // Test
    {
        var taskList = new List<Task>();
        // Subscribe to the event
        MyEvent += MyEventHandlerMethod;

        for(int x = 0; x < 20; x++)
        {
            int y = x;
            Console.WriteLine(y);

            // Raise the event
            Thread detachedThread = new Thread(async (y) =>
            {
                Console.WriteLine((int)y!);

                int count = (int)y!;

                await Task.Delay(3000);

                OnMyEvent(count);

            });

            detachedThread.Start();

            //taskList.Add(Task.Run(async (y) =>
            //{
            //    int count = (int)y;

            //   await Task.Delay(3000);
            //    OnMyEvent(count);
            //}));
        }

        await Task.WhenAll(taskList);


        //OnMyEvent();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void OnMyEvent(int x)
    {
        // Check if there are subscribers to the event
        if (MyEvent != null)
        {
            // Raise the event
            MyEvent.Invoke(x, EventArgs.Empty);
        }
    }

    static void MyEventHandlerMethod(object sender, EventArgs e)
    {
        Console.WriteLine("Event handler method called! - " + (int)sender);
    }
}


//using System;
//using System.Diagnostics;
//using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        // Attach event handler to the ProcessThreadCreated event
//        Process process = Process.GetCurrentProcess();
//        process.EnableRaisingEvents = true;
//        process.Exited += ProcessExited;
//        process.Start();

//        // Wait for the process to exit
//        process.WaitForExit();
//    }

//    static void ProcessExited(object sender, EventArgs e)
//    {
//        Console.WriteLine("Process exited.");
//    }

//    static void ProcessThreadCreated(object senderEventResetMode, ThreadEventArgs e)
//    {
//        Console.WriteLine($"New thread created. Thread ID: {e.Thread.Id}");
//        // Perform any additional actions or logic here
//    }
//}



////using System;
////using System.Diagnostics;
////using System.Numerics;

////class Program
////{
////    static void Main()
////    {
////        int number = 10000; // The number for which factorial will be calculated

////        Stopwatch stopwatch = Stopwatch.StartNew();

////        for (int i = 0; i < 100; i++)
////        {
////            BigInteger factorial = CalculateFactorial(number);

////            Console.WriteLine($"Factorial of {number} is: {factorial}");
////        }

////        stopwatch.Stop();


////        Console.WriteLine($"Calculation took: {stopwatch.Elapsed.TotalSeconds} seconds");

////        Console.ReadKey();
////    }

////    static BigInteger CalculateFactorial(int n)
////    {
////        if (n == 0)
////            return 1;
////        else
////            return n * CalculateFactorial(n - 1);
////    }
////}
