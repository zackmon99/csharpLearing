using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating customer Zack");
            Customer cust = new Customer(1, "zack");
            Console.WriteLine(cust.Say());
            cust.Do();

            Console.WriteLine("Creating customer Kyle");
            CorporateCustomer cCust = new CorporateCustomer(2, "Kyle", "WTW");
            Console.WriteLine(cCust.Say());
            cCust.Do();

            Console.WriteLine("Creating customer Bob");
            Customer cCust2 = new CorporateCustomer(3, "Bob", "Best Buy");
            // As you can see, method hiding does not make Say() use the CorporateCustomer's
            // Say() method, but overriding a virtual method WILL use the CorporateCustomer's
            // Do() method as shown.
            Console.WriteLine(cCust2.Say());
            cCust2.Do();


        }
    }
}
