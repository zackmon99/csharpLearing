using System;
using System.Dynamic;

namespace Delegates
{
    public delegate void AddDelegate(int a, int b);
    public delegate string GreetingsDelagate(string name);
    public class Program
    {
        //NonStatic method
        public void Add(int x, int y)
        {
            Console.WriteLine(@"The Sum of {0} and {1}, is {2} ", x, y, (x + y));
        }
        //Static Method
        public static string Greetings(string name)
        {
            return "Hello @" + name;
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //calling non static method through object
            // obj.Add(100, 100);
            AddDelegate ad = new AddDelegate(obj.Add);

            ad(100, 100);

            GreetingsDelagate gd = new GreetingsDelagate(Program.Greetings);
            //Calling static method with class name
            string GreetingsMessage = gd("Zack");
            Console.WriteLine(GreetingsMessage);

            // Using an anonymous method:
            // Anonymous functions cannot:
            // 1. Use 'jump', 'goto', 'break', 'continue'
            // 2. Use ref or out
            // 3. Use 'unsafe code.
            GreetingsDelagate gd2 = delegate (string name)
            {
                return "GREETINGS " + name + " HOW ARE YOU?? THIS IS AN ANONYMOUS FUNCTION";
            };

            Console.WriteLine(gd2("ZACK"));
        }
    }
}
