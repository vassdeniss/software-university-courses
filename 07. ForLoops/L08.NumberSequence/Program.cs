using System;

namespace L08.NumberSequence {
    class Program {
        static void Main(string[] args) {
            int n = int.Parse(Console.ReadLine());
            int tempA = 0;
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < n; i++) {
                tempA = int.Parse(Console.ReadLine());
                if (tempA > max) { max = tempA; }
                if (tempA < min) { min = tempA; }
            }

            Console.WriteLine($"Max number: {max}\nMin number: {min}");
        }
    }
}
