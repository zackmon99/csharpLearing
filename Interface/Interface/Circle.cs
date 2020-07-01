using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class Circle : Area
    {
        public void Area(double a, double b)
        {
            double circleArea = 3.14159 * a * a;
            Console.WriteLine("The area of the circle is: {0:0.000}", circleArea );
        }
    }
}
