using System;

namespace E05.Time_15 {
    class Program {
        static void Main(string[] args) {
            const int OFFSET = 15;
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            minutes += OFFSET;

            if (minutes >= 60) { minutes = minutes - 60; hours++; }
            if (hours > 23) { hours = 0; }


            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
