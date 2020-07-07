using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            // Generic method in a non-generic class
            int val1 = 5;
            int val2 = 10;

            Console.WriteLine(Calculator.AreEqual<int>(val1, val2));
            Console.WriteLine(Calculator.AreEqual<int>(val1, 5));

            // Generic class with generic methods
            GenericClass<int> gen1 = new GenericClass<int>(3);

            gen1.genericProperty = 6;
            Console.WriteLine("Generic property is {0}", gen1.genericProperty);

            gen1.genericMethod(66);

            GenericClass<string> gen2 = new GenericClass<string>("Hello");
            gen2.genericProperty = "Greetings";
            Console.WriteLine("Generic property is {0}", gen2.genericProperty);

            gen2.genericMethod("Salutations");

            // Generic list
            List<int> integerList = new List<int>();

            Console.WriteLine("Initial Capacity: " + integerList.Capacity);
            integerList.Add(10);
            Console.WriteLine("Capacity after adding first item: " + integerList.Capacity);
            integerList.Add(20);
            integerList.Add(30);
            integerList.Add(40);
            Console.WriteLine("Capacity after adding fourth item: " + integerList.Capacity);
            integerList.Add(60);
            Console.WriteLine("Capacity after adding 5th element: " + integerList.Capacity);
            //Printing the List items using for loop 
            Console.WriteLine("Printing the List items using for loop:");
            for (int i = 0; i < integerList.Count; i++)
            {
                Console.Write(integerList[i] + "  ");
            }
            Console.WriteLine();

            integerList.Remove(20);
            Console.WriteLine("Capacity after removing an element: " + integerList.Capacity);

            integerList.Insert(2, 25);
            Console.WriteLine("List items after inserting the value 25 in the index 2");
            foreach (int item in integerList)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();

            List<int> newIntegerList = new List<int>(integerList);

            Console.WriteLine("Initial capacity of new list collection:" + newIntegerList.Capacity);
            // Printing the values of the new list collection using foreach loop
            Console.WriteLine("Printing the new List items which is created from the old list");
            foreach (int item in newIntegerList)
            {
                Console.Write(item + "  ");
            }

        }
    }

    public class Calculator
    {
        public static bool AreEqual<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }

    public class GenericClass<T>
    {
        private T _genericMember;

        public GenericClass(T value)
        {
            _genericMember = value;
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), _genericMember);
            return _genericMember;
        }

        public T genericProperty { get; set; }
    }
}
