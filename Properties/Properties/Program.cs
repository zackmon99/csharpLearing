using System;

namespace Properties
{   
    public class Example
    {
        private int _empid, _eage;
        private string _ename, _eaddress;

        public int empid
        {
            set
            {
                Console.WriteLine("Using setter");
                _empid = value;
            }

            get
            {
                Console.WriteLine("Using getter");
                return _empid;
            }
        }

        public int eage
        {
            set
            {
                Console.WriteLine("Using setter");
                _eage = value;
            }

            get
            {
                Console.WriteLine("Using getter");
                return _eage;
            }
        }

        public string ename
        {
            set
            {
                Console.WriteLine("Using setter");
                _ename = value;
            }

            get
            {
                Console.WriteLine("Using getter");
                return _ename;
            }
        }

        public string eaddress
        {
            set
            {
                Console.WriteLine("Using setter");
                _eaddress = value;
            }

            get
            {
                Console.WriteLine("Using getter");
                return _eaddress;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Example obj1 = new Example();

            obj1.empid = 202;
            obj1.ename = "ZACK";
            obj1.eage = 30;
            Console.WriteLine("Employee details are:");
            Console.WriteLine("employee id:" + obj1.empid);
            Console.WriteLine("employee name:" + obj1.ename);
            Console.WriteLine("employee age:" + obj1.eage);
            Console.WriteLine("employee address:" + obj1.eaddress);
        }
    }
}
