using System;

namespace E04.VacationBooksList {
    class Program {
        static void Main(string[] args) {
            int numberPages = int.Parse(Console.ReadLine());
            double pagesPerHour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double hoursPerDay = (numberPages / pagesPerHour) / days;
            Console.WriteLine(hoursPerDay);
        }
    }
}
