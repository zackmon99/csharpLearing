using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClasses
{
    public partial class PartialEmployee
    {
        private string _gender;

        public void Display()
        {
            Console.WriteLine("Employee Details:");
            Console.WriteLine("Name: {0}", _name);
            Console.WriteLine("Gender: {0}", _gender);
            Console.WriteLine("Salary: {0}", _salary);
        }

        // Partial method defined.
        partial void PartialMethod()
        {
            Console.WriteLine("Partial PartialMethod invoked");
        }
    }
}
