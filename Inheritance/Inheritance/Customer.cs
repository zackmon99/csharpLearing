using System;

namespace Inheritance
{
    public class Customer
    {
        private int _id;
        private string _name;
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Customer()
        {

        }

        public Customer(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public string Say()
        {
            return "Id is: " + _id + "\nName is: " + _name;
        }

        public virtual void Do()
        {
            Console.WriteLine("Customer is doing something");
        }
    }
}
