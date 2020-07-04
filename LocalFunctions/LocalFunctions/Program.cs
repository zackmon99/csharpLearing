using System;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 5;
            int sum = Sum(a, b);
            int difference = Difference(a, b);
            Console.WriteLine($"The Sum of {a} and {b} is {sum}");
            Console.WriteLine($"The Difference of {a} and {b} is {difference}");
            int Sum(int x, int y)
            {
                return x + y;
            }
            int Difference(int x, int y)
            {
                return x - y;
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
