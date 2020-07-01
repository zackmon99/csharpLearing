using System;

namespace OverridingEquals
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get { 
                return _lastName; 
            }

            set
            {
                _lastName = value;
            }

        }

        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }

            // is keyword
            if (!(obj is Customer))
            {
                return false;
            }

            // Must cast obj to Customer if using object as the parameter
            return (this.FirstName == ((Customer)obj).FirstName)
                && (this.LastName == ((Customer)obj).LastName);
        }

        // Must override GetHashCode method when overriding Equals method
        // or else you get a compiler warning. Objects that are equal
        // should return the same hash.  There are many ways to implement
        // this.
        public override int GetHashCode()
        {
            // ^ is bitwise XOR
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
