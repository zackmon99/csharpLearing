using System;

namespace PartialClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            // Partial employee is split into two files using the
            // partial keyword.  Both files have access direct to each other
            // INCLUDING their private variables
            PartialEmployee emp = new PartialEmployee();
            emp.Name = "Zack";
            emp.Salary = 1000000;
            emp.Gender = "Male";
            emp.Display();

            emp.PublicMethod();
        }
    }
}
