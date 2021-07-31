using System;

namespace L03.SumNumbers {
    class Program {
        static void Main(string[] args) {
            int startNumber = int.Parse(Console.ReadLine());
            int total = 0;

            while (total < startNumber) {
                total += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(total);
        }
    }
}
