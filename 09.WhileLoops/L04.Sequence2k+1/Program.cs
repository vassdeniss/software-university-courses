using System;

namespace L04.Sequence2k_1 {
    class Program {
        static void Main(string[] args) {
            int input = int.Parse(Console.ReadLine());
            int step = 1;

            while (step <= input) {
                Console.WriteLine(step);
                step = 2 * step + 1;
            }
        }
    }
}
