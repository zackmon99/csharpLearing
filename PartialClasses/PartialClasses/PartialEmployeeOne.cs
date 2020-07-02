using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClasses
{
    public partial class PartialEmployee
    {
        private string _name;
        private double _salary;

        // Partial method declared
        partial void PartialMethod();

        public void PublicMethod()
        {
            Console.WriteLine("Public method invoked");
            // If partial method is not yet defined, this call will be
            // ignored.  This seems to be a collaboration tool.
            PartialMethod();
        }

        public string Name
        {
            get
            {
                return _name;   
            }
            set { 
                _name = value; 
            }
        }

        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
    }
}
