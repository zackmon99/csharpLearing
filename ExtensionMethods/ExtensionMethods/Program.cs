using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            OldClass obj = new OldClass();
            obj.Test1();
            obj.Test2();
            obj.Test3();
            obj.Test4(10);
            obj.Test5();
        }
    }
}
