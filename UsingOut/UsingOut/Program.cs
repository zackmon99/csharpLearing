using System;
using System.Runtime.CompilerServices;

namespace UsingOut
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // So this is basically pass by reference in c++.  IE: &Name, &Gender, &Salary, &Department
            // Additionally, calling a method with out variables can declare it at the same time,
            // as I do here.  This is new in C#7
            // You can ignore a vairable by using _ .  For example, if I did not want to create a
            // Department variable, I could say 'out _' in the last parameter.
            GetEmployeeDetails(out var Name, out var Gender, out var Salary, out var Department);

            Console.WriteLine("Employee Details:");
            Console.WriteLine("Name: {0}\nGender: {1}\nSalary: {2}\nDept: {3}", Name, Gender, Salary, Department);

            // out variables are generally used with TryParse
            string s = "June 5, 2005";
            DateTime date;

            if(DateTime.TryParse(s, out date))
            {
                Console.WriteLine(date);
            }

            string x = "600.523y";
            // you can still declare the out variable in TryParse.
            // When TryParse returns false, it could not figure it out.
            // It then assigns the out variable the default value.
            if(double.TryParse(x, out double y))
            {
                Console.WriteLine(y.GetType() + " " + y);
            }
            else
            {
                Console.WriteLine("TryParse didn't work.  Default value: " + y);
            }
        }

        static void GetEmployeeDetails(out string Name, out string Gender, out long Salary, out string Department)
        {
            Name = "Zack";
            Gender = "Male";
            Salary = 1000000;
            Department = "RnD";
        }
    }

    
}
