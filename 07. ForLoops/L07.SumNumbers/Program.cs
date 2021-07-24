using System;

namespace L07.SumNumbers {
    class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int total = 0;

            for (int i = 0; i < n; i++) {
                total += int.Parse(Console.ReadLine());
            }

            Console.WriteLine(total);
        }
    }
}
