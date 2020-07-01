using System;

namespace CheckedUnchecked
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(int.MaxValue);

            int a = int.MaxValue;
            int b = int.MaxValue;

            int c = a + b;
            Console.WriteLine(c);
            // The following will error because is checked
            try
            {
                int d = checked(a + b);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow detected");
                Console.WriteLine(e.Message);
            }

            // Now, if I make const values that overflow,
            // that will be checked at compile time and
            // will cause an error during build.  Use
            // unchecked keyword to ignore.

            const int i = int.MaxValue;
            const int j = int.MaxValue;

            // int k = i+j; will cause an error during
            // compile time.
            int k = unchecked(i + j);
            Console.WriteLine(k);

        }
    }
}
