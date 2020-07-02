using System;
using System.Linq;

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

            string test = "A fine day";
            Console.WriteLine("The string has " + test.GetWordCount() + " words");
        }
    }

    // Extending string
    public static class StringExtension
    {
        public static int GetWordCount(this string inputstring)
        {
            if (!string.IsNullOrEmpty(inputstring))
            {
                string[] strArray = inputstring.Split(' ');
                return strArray.Count();
            }
            else
            {
                return 0;
            }
        }
        
    }
}
