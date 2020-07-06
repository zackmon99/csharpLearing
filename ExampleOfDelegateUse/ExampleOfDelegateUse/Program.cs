using System;
using System.Collections.Generic;

namespace ExampleOfDelegateUse
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee()
            {
                ID = 101,
                Name = "Pranaya",
                Gender = "Male",
                Experience = 5,
                Salary = 10000
            };
            Employee emp2 = new Employee()
            {
                ID = 102,
                Name = "Priyanka",
                Gender = "Female",
                Experience = 10,
                Salary = 20000
            };
            Employee emp3 = new Employee()
            {
                ID = 103,
                Name = "Anurag",
                Experience = 5,
                Salary = 30000
            };

            List<Employee> employees = new List<Employee>();
            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);

            // We are making the Promote method of Program the delegate for EligibleForPromotion
            Console.WriteLine("Promoting by Salary");
            EligibleForPromotion eligibleForPromotion = new EligibleForPromotion(Program.Promote);
            // Now we promote the employees, passing the new function delegate.
            Employee.PromoteEmployees(employees, eligibleForPromotion);

            // Lambda functions.
            Console.WriteLine("Promoting by years of experience");
            Employee.PromoteEmployees(employees, x => x.Experience > 5);
        }

        // Here we can define a function that excepts the same arguements as EligibleForPromotion
        public static bool Promote(Employee employee)
        {
            if (employee.Salary > 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
