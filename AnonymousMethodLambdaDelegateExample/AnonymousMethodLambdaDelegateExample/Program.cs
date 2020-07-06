using System;
using System.Collections.Generic;

namespace AnonymousMethodLambdaDelegateExample
{
    // Employee class
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create the collection
            List<Employee> employees = new List<Employee>()
            {
                new Employee{ ID = 101, Name = "Zack", Gender = "Male", Salary = 1000000},
                new Employee{ ID = 102, Name = "Priyanka", Gender = "Female", Salary = 200000},
                new Employee{ ID = 103, Name = "Anurag", Gender = "Male", Salary = 300000},
                new Employee{ ID = 104, Name = "Preety", Gender = "Female", Salary = 400000},
                new Employee{ ID = 104, Name = "Sambit", Gender = "Male", Salary = 500000}
            };

            Predicate<Employee> predicate = new Predicate<Employee>(GetEmployee);
            // So the collections stuff includes methods that accept predicates
            // This is a lambda expression that returns true or false and has 1
            // argument, so it is a predicate
            Employee employee = employees.Find(x => GetEmployee(x));
            // Could completely define the lambda expression inline, though
            // I'm finding id 101
            Employee employee2 = employees.Find(x => x.ID == 101);
            // Mouse-over 'Find' for more information about what is going on here
            // I assume that it is taking this lambda function and running this
            // function on each method until it returns true, then returns a copy of
            // the object that matched

            Console.WriteLine(@"ID: {0}, Name: {1}, Gender {2}, Salary: {3}", employee.ID, employee.Name, employee.Gender, employee.Salary);
            Console.WriteLine(@"ID: {0}, Name: {1}, Gender {2}, Salary: {3}", employee2.ID, employee2.Name, employee2.Gender, employee2.Salary);

          
            employee.Name = "NOT ZACK";
            Console.WriteLine(employees[0].Name);

            // Just some review of references in c#
            ref Employee employee3 = ref employee2;
            employee3.Name = "New Name!";
            Console.WriteLine(employee2.Name);

         

        }
        private static bool GetEmployee(Employee employee)
        {
            return employee.ID == 103;
        }
    }
}
