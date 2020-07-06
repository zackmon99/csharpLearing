using System;

namespace GenericDelegates
{
    class Program
    {
    
        static void Main(string[] args)
        {
            // Func Generic Delegate
            // All but the last parameter are input parameters.  The last one is the return type.
            // Since AddNumber one has int, float, double an returns double, 
            // Func<int, float, double, double> is how you declare it
            Func<int, float, double, double> del1 = new Func<int, float, double, double>(AddNumber1);
            Console.WriteLine(del1(50, 255.45f, 123.456));

            // Action Generic Delegate
            // Actions are just like func, but always return void.  Also takes a max of 16
            // input parameters.
            Action<int, float, double> del2 = new Action<int, float, double>(AddNumber2);
            del2(50, 255.45f, 123.456);

            // Predicate Generic Delegate
            // Predicates take ONE input parameter and return a bool
            // That is the only option
            Predicate<string> del3 = new Predicate<string>(CheckLength);
            Console.WriteLine(del3("ZACK"));
        }

        public static double AddNumber1(int no1, float no2, double no3)
        {
            return no1 + no2 + no3;
        }

        public static void AddNumber2(int no1, float no2, double no3)
        {
            Console.WriteLine(no1 + no2 + no3);
        }

        public static bool CheckLength(string name)
        {
            if (name.Length > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
