using System;
using System.Threading;

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

    class Shorthand
    {
        public int a { get; set; }
        public int b { get; set; }

        public int Add()
        {
            return a + b;
        }
    }

    class Student
    {
        private int _id;
        private string _name;
        private int _passMark = 35;

        public void SetId(int id)
        {
            if (id < 0)
            {
                throw new Exception("ID must be > 0");
            }
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("Name must be something");
            }
            _name = name;
        }

        public string GetName()
        {
            if (string.IsNullOrEmpty(_name))
            {
                return "No Name...";
            }
            return _name;
        }

        public int GetPassMark()
        {
            return _passMark;
        }
    }

    class Student2
    {
        private int _id;
        private string _name;
        private int _passMark = 35;

        public int ID
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("ID must be > 0");
                }
                _id = value;
            }

            get
            {
                return _id;
            }
        }
    
   

        public string Name
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Name must be something");
                }
                _name = value;
            }

            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return "No Name...";
                }
                return _name;
            }
        }

        

        public int PassMark
        {
            get
            {
                return _passMark;
            }
        }

        public override string ToString()
        {
            return "ID: " + _id + "\nName: " + _name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("---FIRST EXAMPLE---");

            Example obj1 = new Example();

            obj1.empid = 202;
            obj1.ename = "ZACK";
            obj1.eage = 30;
            Console.WriteLine("Employee details are:");
            Console.WriteLine("employee id:" + obj1.empid);
            Console.WriteLine("employee name:" + obj1.ename);
            Console.WriteLine("employee age:" + obj1.eage);
            Console.WriteLine("employee address:" + obj1.eaddress);

            // Shorthand stuff
            Console.WriteLine("---SHORTHAND EXAMPLE---");
            Shorthand sh = new Shorthand();
            sh.a = 1;
            sh.b = 2;
            Console.WriteLine(sh.Add());

            // Secure stuff.  This is the old long way of doing things
            Console.WriteLine("--SECURE EXAMPLE---");
            Student student = new Student();
            Console.WriteLine("Enter Student Id:");
            try
            {
                student.SetId(int.Parse(Console.ReadLine()));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                student.SetId(99999);
            }

            Console.WriteLine("Enter Student Name:");
            try
            {
                student.SetName(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                student.SetName("BAD NAME");
            }

            Console.WriteLine("Student ID = {0}", student.GetId());
            Console.WriteLine("Student Name = {0}", student.GetName());
            Console.WriteLine("Student Pass Mark = {0}", student.GetPassMark());

            // Secure stuff.  This is the new short way of doing things
            Console.WriteLine("--SECURE EXAMPLE 2---");
            Student2 student2 = new Student2();
            Console.WriteLine("Enter Student Id:");
            try
            {
                student2.ID = int.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                student2.ID = 9999;
            }

            Console.WriteLine("Enter Student Name:");
            try
            {
                student2.Name = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                student2.Name = "BAD NAME";
            }

            Console.WriteLine("Student ID = {0}", student2.ID);
            Console.WriteLine("Student Name = {0}", student2.Name);
            Console.WriteLine("Student Pass Mark = {0}", student2.PassMark);

            Console.WriteLine(student2.ToString());


        }
    }
}
