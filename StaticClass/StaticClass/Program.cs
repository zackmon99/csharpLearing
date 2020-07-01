using System;

namespace StaticClass
{
    public static class FtoC
    {
        public static double FahrenHeitToCelcius(string tempF)
        {
            double fahrenheit = Double.Parse(tempF);
            double celcius = (fahrenheit - 32) * 5 / 9;

            return celcius;
        }

        public static double CelciusToFahrenheit(string tempC)
        {
            double celcius = Double.Parse(tempC);
            return (celcius * 9 / 5) + 32;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine(FtoC.FahrenHeitToCelcius("334"));
            Console.WriteLine(FtoC.CelciusToFahrenheit("222"));


            Console.Write("Please enter F:");
            string tempF = Console.ReadLine();

            double C = FtoC.FahrenHeitToCelcius(tempF);

            Console.WriteLine("Temperature in Celsius: {0:F2}", C);

        }
    }
}
