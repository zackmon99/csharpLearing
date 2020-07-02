using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    // MUST BE STATIC
    public static class NewClass
    {
        public static void Test3(this OldClass old)
        {
            Console.WriteLine("Method Three");
        }

        // This takes one parameter, x.  This is not the same x
        // that is in OldClass
        public static void Test4(this OldClass old, int x)
        {
            Console.WriteLine("Method 4: " + x);
        }

        public static void Test5(this OldClass old)
        {
            Console.WriteLine("Method 5: " + old.x);
        }
    }
}
