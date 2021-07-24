using System;

namespace E01.Cinema {
    class Program {
        static void Main(string[] args) {
            const double PREMIERE_PRICE = 12;
            const double NORMAL_PRICE = 7.50;
            const double DISCOUNT_PRICE = 5;

            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine()); 
            int columns = int.Parse(Console.ReadLine());

            int totalSeats = rows * columns;
            double total = 0.0;

            switch (projectionType) {
                case "Premiere": total += totalSeats * PREMIERE_PRICE; break;
                case "Normal": total += totalSeats * NORMAL_PRICE; break;
                case "Discount": total += totalSeats * DISCOUNT_PRICE; break;
            }

            Console.WriteLine($"{total:f2} leva");
        }
    }
}
