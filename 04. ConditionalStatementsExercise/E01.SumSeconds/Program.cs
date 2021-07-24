using System;

namespace E01.SumSeconds {
    class Program {
        static void Main(string[] args) {
            int timeOne = int.Parse(Console.ReadLine());
            int timeTwo = int.Parse(Console.ReadLine());
            int timeThree = int.Parse(Console.ReadLine());

            int totalSeconds = timeOne + timeTwo + timeThree;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            if (seconds < 10) { Console.WriteLine($"{minutes}:{seconds:d2}");} 
            else { Console.WriteLine($"{minutes}:{seconds}"); }
        }
    }
}
