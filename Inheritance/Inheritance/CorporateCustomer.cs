using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class CorporateCustomer : Customer
    {
        private string _companyName;

        public string CompanyName
        {
            get
            {
                return _companyName;
            }

            set
            {
                _companyName = value;
            }
        }

        // this is an example of calling the base class constructor when given this argument list
        // this is just like C++ except you use the keyword base rather than the base class's name
        public CorporateCustomer(int id, string name, string companyName) : base(id, name)
        {
            _companyName = companyName;
        }

        // If not a virtual method, you must include new keyword.  This implements
        // 'Method Hiding'
        new public string Say()
        {
            // Gotta use the property here because _id is private.
            // if it were protected (or public), you could access it directly
            // It probably would be smart to make id and name protected
            // but I want to demonstrate access levels here
            return "Id is: " + ID + "\nName is " + Name + "\nCompany Name is " + _companyName;
        }

        // Override is needed to override a virtual method
        public override void Do()
        {
            Console.WriteLine("Corporate customer is doing something.");
        }

        
    }
}
