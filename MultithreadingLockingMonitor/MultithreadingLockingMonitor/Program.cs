using System;
using System.Threading;

namespace MultithreadingLockingMonitor
{
    // Delegate for t10
    public delegate void ResultCallbackDelegate(int result);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started.");

            // START OF LOCK DEMO
            Console.WriteLine("START OF LOCK DEMO");
            // Without locking!
            Console.WriteLine("Starting threads without locking");
            // Creating thread objects
            Thread t1 = new Thread(DisplayMessageNoLock);
            Thread t2 = new Thread(DisplayMessageNoLock);
            Thread t3 = new Thread(DisplayMessageNoLock);

            // Starting threads
            t1.Start();
            t2.Start();
            t3.Start();

            // Wait for threads to complete before continuing
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Done with no lock demo");

            // With locking!
            Console.WriteLine("Now with locking");
            // (ThreadStart) needed due to overloaded method
            Thread t4 = new Thread((ThreadStart)DisplayMessage);
            Thread t5 = new Thread((ThreadStart)DisplayMessage);
            Thread t6 = new Thread((ThreadStart)DisplayMessage);

            // Start threads
            t4.Start();
            t5.Start();
            t6.Start();

            // Wait for threads to complete
            t4.Join();
            t5.Join();
            t6.Join();
            Console.WriteLine("Done with lock demo");

            // With locking and input parameter
            Console.WriteLine("Locking demo with input parameter of 500");
            ParameterizedThreadStart pt1 = new ParameterizedThreadStart(DisplayMessage);
            Thread t7 = new Thread(pt1);
            Thread t8 = new Thread(pt1);

            // Start threads
            t7.Start(500);
            t8.Start(500);

            // Wait for threads to complete
            t7.Join();
            t8.Join();
            Console.WriteLine("Done with Locking demo with input parameter of 500");

            // Type-safe
            Console.WriteLine("Locking demo with type-safe input parameter of 500");
            MessageDisplayer md1 = new MessageDisplayer(500);
            Thread t9 = new Thread(md1.DisplayMessage);
            Thread t10 = new Thread(md1.DisplayMessage);

            // Start threads
            t9.Start();
            t10.Start();

            // Wait for threads to complete
            t9.Join();
            t10.Join();
            Console.WriteLine("Done with Locking demo with type-safe input parameter of 500");

            // With type-safe with callback function
            Console.WriteLine("Locking demo with type-safe input parameter of 500 and callback function");
            ResultCallbackDelegate resultCallback = new ResultCallbackDelegate(ResultCallbackMethod);
            MessageDisplayerWithRetrieve mdr1 = new MessageDisplayerWithRetrieve(500, resultCallback);
            Thread t11 = new Thread(mdr1.DisplayMessage);
            Thread t12 = new Thread(mdr1.DisplayMessage);

            
            t11.Start();
            t12.Start();

            // Wait for threads to complete
            t11.Join();
            t12.Join();
            Console.WriteLine("Done with Locking demo with type-safe input parameter of 500 and callback function");

            Console.WriteLine("END OF LOCK DEMO");
            // END OF LOCK DEMO

            // START OF MONITOR DEMO

            // Making and array of threads
            Thread[] Threads = new Thread[4];
            // Obstantiating object that I want to lock
            // See definition for use of Monitor methods
            DisplayNumbersMonitorClass dnmc1 = new DisplayNumbersMonitorClass();
            
            // Assign function to threads
            for(int i = 0; i < Threads.Length; i++)
            {
                Threads[i] = new Thread(dnmc1.PrintNumbers);
                Threads[i].Name = "Child Thread " + i;
            }

            // Start each thread
            foreach(Thread t in Threads)
            {
                t.Start();
            }

            // Wait for each thread to complete
            foreach(Thread t in Threads)
            {
                t.Join();
            }
            Console.WriteLine("Main thread done.");

        }

        // LOCK DEMO METHODS
        static void DisplayMessageNoLock()
        {
            Console.Write("Welcom sir... ");
            Thread.Sleep(1000);
            Console.WriteLine("Zack");
        }

        private static object _lock = new object();
        static void DisplayMessage()
        {
            lock (_lock)
            {
                Console.Write("Welcom sir... ");
                Thread.Sleep(1000);
                Console.WriteLine("Zack");
            }
        }

        static void DisplayMessage(object wait)
        {
            lock (_lock)
            {
                Console.Write("Welcom sir... ");
                Thread.Sleep(Convert.ToInt32(wait));
                Console.WriteLine("Zack");
            }
        }

        static void ResultCallbackMethod(int result)
        {
            Console.WriteLine("Wait time was " + result);
        }
        // END OF LOCK DEMO METHODS

    }

    // LOCK DEMO CLASSES
    public class MessageDisplayer
    {
        // needs lock object in scope
        private object _lock = new object();
        private int _Wait;

        public MessageDisplayer(int Wait)
        {
            _Wait = Wait;
        }

        public void DisplayMessage()
        {
            lock (_lock)
            {
                Console.Write("Welcom sir... ");
                Thread.Sleep(_Wait);
                Console.WriteLine("Zack");
            }
        }
    }
    public class MessageDisplayerWithRetrieve
    {
        // lock object needed in scope
        private object _lock = new object();
        private int _Wait;
        private ResultCallbackDelegate _resultCallbackDelegate;

        public MessageDisplayerWithRetrieve(int Wait, ResultCallbackDelegate resultCallbackDelegate)
        {
            _Wait = Wait;
            _resultCallbackDelegate = resultCallbackDelegate;
        }

        public void DisplayMessage()
        {
            lock (_lock)
            {
                Console.Write("Welcom sir... ");
                Thread.Sleep(_Wait);
                Console.WriteLine("Zack");

                if(_resultCallbackDelegate != null)
                {
                    _resultCallbackDelegate(_Wait);
                }
            }
        }
   
    }
    // END OF LOCK DEMO CLASSES

    // START OF MONITOR CLASSES
    public class DisplayNumbersMonitorClass
    {
        public void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " trying to enter critical section");
            Monitor.Enter(this);
            // Can also use the following if you want to have access to a boolean that states whether lock is taken
            // bool isLockTaken = false;
            // Monitor(this, ref isLockTaken);
            // The above is generally more useful if the bool is accessible from outside, I would imagine.

            // Try block is here, because no matter what, we want object to be released inn
            // finally block
            try
            {
                Console.WriteLine(Thread.CurrentThread.Name + " has entered critical section");
                for(int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write(i + ", ");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(this);
                Console.WriteLine(Thread.CurrentThread.Name + " has exited critical section");
            }
        }
    }
}
