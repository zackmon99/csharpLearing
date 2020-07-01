using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritanceUsingInterfaces
{
    class ImplementInterface : Interface1, Interface2
    {
        void Interface1.Show()
        {
            Console.WriteLine("Show method of interface1 is implemented");
        }

        void Interface1.Test()
        {
            Console.WriteLine("Test method of interface1 is implemented");
        }

        void Interface2.Show()
        {
            Console.WriteLine("Show method of interface2 is implemented");
        }

        void Interface2.Test()
        {
            Console.WriteLine("Test method of interface2 is implemented");
        }
    }
}
