using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleOfDelegateUse
{
    // We've declared the delegate here
    public delegate bool EligibleForPromotion(Employee employee);
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }

        // The delegate is one of the parameters here
        public static void PromoteEmployees(List<Employee> lstEmployees, EligibleForPromotion eligibleForPromotion)
        {
            foreach(Employee employee in lstEmployees)
            {
                // Using the delegate function here.
                if (eligibleForPromotion(employee))
                {
                    Console.WriteLine("Employee {0} Promoted", employee.Name);
                }
            }
        }
    }
}
