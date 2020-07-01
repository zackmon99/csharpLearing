using System;

namespace MultipleInheritanceUsingInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            ImplementInterface obj = new ImplementInterface();
            // Cannot do obj.Test() or obj.Show()
            // Must cast to correct interface!
            ((Interface1)obj).Test();
            ((Interface1)obj).Show();

            ((Interface2)obj).Test();
            ((Interface2)obj).Show();

            // Now there is no need to cast
            Interface1 obj1 = new ImplementInterface();
            obj1.Test();
            obj1.Show();

            Interface2 obj2 = new ImplementInterface();
            obj2.Test();
            obj2.Show();
        }
    }
}
