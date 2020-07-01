using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class Rectangle : Area
    {
        public void Area(double a, double b)
        {
            Console.WriteLine("The area of the rectangle is: " + (a * b));
        }
    }
}
