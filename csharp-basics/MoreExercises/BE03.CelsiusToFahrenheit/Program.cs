using System;

namespace BE03.CelsiusToFahrenheit {
    class Program {
        static void Main(string[] args) {
            double celcius = double.Parse(Console.ReadLine());
            double farenheit = (celcius * 9 / 5) + 32;
            Console.WriteLine($"{farenheit:f2}");
        }
    }
}
