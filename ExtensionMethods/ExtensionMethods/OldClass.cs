using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public class OldClass
    {
        public int x = 100;
        public void Test1()
        {
            Console.WriteLine("Method one: " + x);
        }

        public void Test2()
        {
            Console.WriteLine("Method two: " + x);
            "This is a test".GetWordCount();
        }
    }
}
