using System;

namespace L03.Combinations {
    class Program {
        static void Main(string[] args) {
            int limit = int.Parse(Console.ReadLine());
            int combinations = 0;

            for (int i = 0; i <= limit; i++) {
                for (int j = 0; j <= limit; j++) {
                    for (int k = 0; k <= limit; k++) {
                        if (i + j + k == limit) {
                            combinations++;
                        }
                    }
                }
            }

            Console.WriteLine(combinations);
        }
    }
}
