using System;

namespace RefReturnsLocals
{
    class Program
    {
        static void Main(string[] args)
        {
            int y = 3;
            // must put ref keyword here.  Probably to try to save you from
            // yourself.
            PassByRef(ref y);
            Console.WriteLine(y);

            // The initialization isn't even really needed here because
            // z will be overwritten by what PassByOut is going to set it.
            int z = 3;
            PassByOut(out z);

            Console.WriteLine(z);

            PassByOut(out int a);
            Console.WriteLine(a);


            // Ref locals
            Console.WriteLine("Initialized no1 to 1");
            int no1 = 1;
            Console.WriteLine("Initialized no2 as ref no1");
            ref int no2 = ref no1;

            Console.WriteLine("Changing no2 to 2.");
            no2 = 2;
            Console.WriteLine($"no1 is {no1}");
            Console.WriteLine("Changing no1 to 3");
            no1 = 3;
            Console.WriteLine($"no2 is {no2}");

            // Ref returns

            int[] x = { 2, 4, 62, 54, 33, 55, 66, 71, 92 };
            // The first odd nubmer is 33
            ref int oddNum = ref GetFirstOddNumber(x); //storing as reference
            // So now oddNum is a reference to the memory location of the first
            // odd number
            Console.WriteLine("First odd number is {0}", oddNum);

            Console.WriteLine("Changing oddNum to 303");
            // So when we change oddNum, we are actually changing what oddNum references
            // So the 5th place in the array itself is changed!
            oddNum = 303;

            Console.WriteLine("Now the array is:");

            foreach(var num in x)
            {
                Console.Write($"{num}\t");
            }

            Console.WriteLine();

        }

        static void PassByRef(ref int x)
        {
            x++;
        }

        // out is a bit different.  Basically you can't change the value you pass in
        // BUT it allows you to initialize the variable. see initialization of variable
        // a
        static void PassByOut(out int x)
        {
            x = 2;
            // x++; does not work, only assignment
        }

        static ref int GetFirstOddNumber(int[] numbers){
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    return ref numbers[i]; //returning as reference  
                }
            }
            throw new Exception("odd number not found");
        }
    }
}
