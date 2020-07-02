using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(10);
            DisplayArea(circle);
            Rectangle rectangle = new Rectangle(10, 5);
            DisplayArea(rectangle);
            Triangle triangle = new Triangle(10, 5);
            DisplayArea(triangle);

            Console.WriteLine("\n---With switch---\n");
            Rectangle square = new Rectangle(5, 5);
            DisplayArea2(circle);
            DisplayArea2(rectangle);
            DisplayArea2(square);
            DisplayArea2(triangle);

        }

        public static void DisplayArea(Shape shape)
        {

            // The following way does not declare a new circle
            /*
            if(shape is Circle)
            {
                Console.WriteLine(Math.Pow(((Circle)shape).Radius, 2) * Shape.PI);
            }
            */

            // This MIGHT be a bit slower since it is assigning a variable, but
            // much more readable
            if (shape is Circle circle)
            {
                Console.WriteLine("Area of Circle is: " + (Math.Pow(circle.Radius, 2) * Shape.PI));
            }
            else if(shape is Rectangle rectangle)
            {
                Console.WriteLine("Area of rectangle is: " + (rectangle.Length * rectangle.Height));
            }
            else if (shape is Triangle triangle)
            {
                Console.WriteLine("Area of triangle is: " + (0.5 * triangle.Base * triangle.Height));
            }
            else
            {
                throw new ArgumentException(message: "Invalid shape", paramName: nameof(shape));
            }
        }

        // Using switch instead
        public static void DisplayArea2(Shape shape)
        {
            switch (shape)
            {
                case Circle c:
                    Console.WriteLine("Area of Circle is: " + (Math.Pow(c.Radius, 2) * Shape.PI));
                    break;
                // You can use when to provide a condition.
                case Rectangle r when r.Height == r.Length:
                    Console.WriteLine("Area of square is: " + (r.Length * r.Height));
                    break;
                case Rectangle r:
                    Console.WriteLine("Area of rectangle is: " + (r.Length * r.Height));
                    break;
                case Triangle t:
                    Console.WriteLine("Area of triangle is: " + (0.5 * t.Base * t.Height));
                    break;
                default:
                    throw new ArgumentException(message: "Invalid shape", paramName: nameof(shape));
                case null:
                    throw new ArgumentNullException(nameof(shape));
            }
        }
    }

    public class Shape
    {
        public const float PI = 3.14f;
    }
    public class Circle : Shape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
    }
    public class Rectangle : Shape
    {
        public double Length { get; }
        public double Height { get; }
        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
    }
    public class Triangle : Shape
    {
        public double Base { get; }
        public double Height { get; }

        public void Method(int t)
        {
            Console.WriteLine("TEST");
        }
        public Triangle(double @base, double height)
        {
            // @base is used because base is a keyword
            Base = @base;
            Height = height;
        }
    }
}
