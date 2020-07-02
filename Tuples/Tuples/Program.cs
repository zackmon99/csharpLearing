using System;
using System.Collections.Generic;
using System.Threading;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new List<double> { 10, 20, 30, 40, 50 };

            // This is the old way.  Tuples are classes (so they are references)
            // Also, the items do not have names so they are accessed with lame
            // names ItemX.  Also has a maximum of 8 values;
            Tuple<int, double> t = Calculate(values);
            Console.WriteLine($"There are {t.Item1} values and their sum is {t.Item2}");

            // This is the new way.  They are not references, so passing them around is not
            // dangerous.
            var result = Calculate2(values);
            Console.WriteLine($"There are {result.count} values and their sum is {result.sum}");

            // You can explicitly name the fields, too
            var (CountResult, SumResult) = Calculate2(values);
            Console.WriteLine($"There are {CountResult} values and their sum is {SumResult}");
        }

        private static Tuple<int, double> Calculate(IEnumerable<double> values)
        {
            int count = 0;
            double sum = 0.0;

            foreach(var value in values)
            {
                count++;
                sum += value;
            }


            Tuple<int, double> t = Tuple.Create(count, sum);

            return t;
        }

        private static (int count, double sum) Calculate2(IEnumerable<double> values) 
        {
            int count = 0;
            double sum = 0.0;
            foreach (var value in values)
            {
                count++;
                sum += value;
            }

            return (count, sum);
        }
    }
}
