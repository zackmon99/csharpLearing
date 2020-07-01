using System;

namespace ConstAndReadonly
{

    class ConstExample
    {
        // Const is static by default
        // Const is defined at compile
        public const int num = 66;
        public static int num2 = 20;

        public int num3;

        public ConstExample(int n)
        {
            num3 = n;
        }
    }

    class ReadOnlyExample
    {
        // Readonly is defined at obstantiation
        public readonly int number = 5;

        public ReadOnlyExample()
        {
            // So we can change it in a constructor!
            number = 22;
        }

        public ReadOnlyExample(bool anotherOne)
        {
            number = 55;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Can't do this
            // ConstExample.num += 1;

            ConstExample.num2 += 1;

            ConstExample ce = new ConstExample(2);

            Console.WriteLine(ConstExample.num);
            Console.WriteLine(ConstExample.num2);
            Console.WriteLine(ce.num3);

            ReadOnlyExample ro1 = new ReadOnlyExample();
            Console.WriteLine("ro1 is {0}", ro1.number);

            ReadOnlyExample ro2 = new ReadOnlyExample(true);
            Console.WriteLine("ro2 is {0}", ro2.number);


        }
    }
}
