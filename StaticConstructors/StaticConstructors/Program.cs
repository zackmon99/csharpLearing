using System;

namespace StaticConstructors
{
    class Example
    {
        int i;
        static int j;

        // Constructors can be private, too,
        // but private constructors can only be invoked
        // from within the class, just like private
        // member variables.
        public Example()
        {
            i = 100;
            // You can also change statics here BUT
            // they lose the static nature
        }

        // This is only ran once during the program
        // so j will keep increasing even when 
        // new instances of Example are created.
        // This makes sense since static variables
        // are to remain the same for all objects of
        // the same type.  IE: j is the same memory
        // location for all Examples
        static Example()
        {
            j = 100;
        }
        public void Display()
        {
            Console.WriteLine("value of i : " + i);
            i++;
            Console.WriteLine("value of j : " + j);
            j++;
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Example e1 = new Example();
            e1.Display();
            e1.Display();
            Example e2 = new Example();
            e2.Display();
            e2.Display();

            Console.WriteLine("Now e1 again...");
            e1.Display();
            Console.ReadKey();

        }
    }
}
