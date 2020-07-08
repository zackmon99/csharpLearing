using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace Multithreading
{
    // Delegate is needed for returning values from threads that need
    // to return stuff
    public delegate void ResultCallbackDelegate(int results);
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = Thread.CurrentThread;
            t.Name = "Main Thread";

            /*
             * This will work, but method 2 has a 10 second delay!
            Method1();
            Method2();
            Method3();
            */

            Console.WriteLine(t.Name + " Started.");
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };

            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };

            Thread t3 = new Thread(Method3)
            {
                Name = "Thread3"
            };

            Program obj = new Program();

            // This works, but is NOT type-safe!
            ParameterizedThreadStart pt1 = new ParameterizedThreadStart(Method4);
            Thread t4 = new Thread(pt1)
            {
                Name = "Thread4"
            };

            // We can make a type-safe thread by creating a class and
            // using its parameters
            NumberHelper nh1 = new NumberHelper(13);
            Thread t5 = new Thread(new ThreadStart(nh1.Method5))
            {
                Name = "Thread5"
            };

            /* Or, could have done this
             * NumberHelper nh1 = new NumberHelper(13);
             * ThreadStart ts1 = new ThreadStart(nh1.Method5);
             * Thread t5 = new Thread(ts1)
             * {
             *      Name = "Thread5"
             * };
             */

            // Using a callback method
            ResultCallbackDelegate resultCallbackDelegate = new ResultCallbackDelegate(ResultCallBackMethod);
            // Pass callback delegate
            NumberHelperWithRetrieve nhr1 = new NumberHelperWithRetrieve(10, resultCallbackDelegate);
            // start thread
            Thread t6 = new Thread(new ThreadStart(nhr1.CalculateSum));


            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start(10);
            t5.Start();
            t6.Start();

            // Using join statement so main thread does not continue
            // until child threads have finished
            t1.Join();
            // Main thread is going to end before t3 because I have set the
            // timeout for 3 seconds and t3 take 10 seconds.
            t2.Join(3000);
            // Or wait till finished
            // t2.Join();
            t4.Join();
            t5.Join();
            t6.Join();

            if (t2.IsAlive)
            {
                Console.WriteLine(t3.Name + " is still doing work");
            }
            else
            {
                Console.WriteLine(t3.Name + " is finished");
            }
            Console.WriteLine("Main Thread ended!");
        }

        static void Method1()
        {
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method 1: " + i);
            }
        }

        static void Method2()
        {
            Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method 2: " + i);
                if (i == 3)
                {
                    Console.WriteLine("Performing LONG operation");
                    Thread.Sleep(10000);
                    Console.WriteLine("Done with LONG operation");
                }
            }
        }

        static void Method3()
        {
            Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method 3:" + i);
            }
        }

        static void Method4(object max)
        {
            Console.WriteLine("Method4 Started using " + Thread.CurrentThread.Name);
            int number = Convert.ToInt32(max);
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine("Method4 :" + i);
            }
        }

        public static void ResultCallBackMethod(int Result)
        {
            Console.WriteLine("The Result is " + Result);
        }
    }

    public class NumberHelper
    {
        int _Number;

        public NumberHelper(int Number)
        {
            _Number = Number;
        }

        public void Method5() 
        {
            Console.WriteLine("Method5 Started using " + Thread.CurrentThread.Name);
            for (int i = 1; i <= _Number; i++)
            {
                Console.WriteLine("Method 5: " + i);
            }
        }
    }

    public class NumberHelperWithRetrieve
    {
        private int _Number;
        private ResultCallbackDelegate _resultCallbackDelegate;

        public NumberHelperWithRetrieve(int Number, ResultCallbackDelegate resultCallbackDelegate)
        {
            _Number = Number;
            _resultCallbackDelegate = resultCallbackDelegate;
        }
        
        public void CalculateSum()
        {
            int Result = 0;
            for(int i = 1; i <= _Number; i++)
            {
                Result += i;
            }

            if(_resultCallbackDelegate != null)
            {
                _resultCallbackDelegate(Result);
            }
        }

        
    }

    



}
