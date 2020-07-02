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

            // Showing more tuple splitting
            // Way 1:
            var EmployeeDetails = GetEmployeeDetails(1001);

            var Name = EmployeeDetails.Item1;
            var Salary = EmployeeDetails.Item2;
            var Gender = EmployeeDetails.Item3;
            var Dept = EmployeeDetails.Item4;
            Console.WriteLine($"Name: {Name},  Gender: {Gender}, Department: {Dept}, Salary:{Salary}");

            // Way 2
            (string Name2, double Salary2, string Gender2, String Dept2) = GetEmployeeDetails(1001);
            Console.WriteLine($"Name: {Name2},  Gender: {Gender2}, Department: {Dept2}, Salary:{Salary2}");

            // Way 3
            // can also use var individually as way 2
            var (Name3, Salary3, Gender3, Dept3) = GetEmployeeDetails(1001);
            Console.WriteLine($"Name: {Name3},  Gender: {Gender3}, Department: {Dept3}, Salary:{Salary3}");

            // Way 4
            string Name4;
            double Salary4;
            string Gender4 = "Female";
            string Dept4 = "HR";

            (Name4, Salary4, Gender4, Dept4) = GetEmployeeDetails(1001);
            Console.WriteLine($"Name: {Name4},  Gender: {Gender4}, Department: {Dept4}, Salary:{Salary4}");

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

        private static (string, double, string, string) GetEmployeeDetails(long EmployeeID)
        {
            string EmployeeName = "Zack";
            double Salary = 1_000_000;
            string Gender = "Male";
            string Department = "Software Dev";

            return (EmployeeName, Salary, Gender, Department);
        }
    }
}
