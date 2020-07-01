using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating customer Zack");
            Customer cust = new Customer(1, "zack");
            Console.WriteLine(cust.say());

            Console.WriteLine("Creating customer Kyle");
            CorporateCustomer cCust = new CorporateCustomer(2, "Kyle", "WTW");
            Console.WriteLine(cCust.say());

        }
    }
}
