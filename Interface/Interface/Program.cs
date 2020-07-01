using System;

namespace Interface
{
    // Interfaces say that methods must be defined in classes that
    // implement the interface.  In here, I make the Area interface
    // and make Rectangle and Circle implement them.
    // The interface requires the classes to implement the Area() method
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle();
            Circle circle = new Circle();

            rec.Area(3, 4);
            circle.Area(4, 4);
        }
    }
}
