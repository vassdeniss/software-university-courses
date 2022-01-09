using System;

namespace BE09.WeatherForecast {
    class Program {
        static void Main(string[] args) {
            string weather = Console.ReadLine();
            if (weather == "sunny") { Console.WriteLine("It's warm outside!"); }
            else { Console.WriteLine("It's cold outside!"); }
        }
    }
}
