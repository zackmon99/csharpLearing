using System;
using System.Threading;

namespace Multithreading
{
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

            t1.Start();
            t2.Start();
            t3.Start();
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
    }
}
