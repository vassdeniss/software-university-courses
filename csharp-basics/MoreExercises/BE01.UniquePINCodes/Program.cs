using System;

namespace BE01.UniquePINCodes {
    class Program {
        static void Main(string[] args) {
            int firstNumberMax = int.Parse(Console.ReadLine());
            int middleNumberMax = int.Parse(Console.ReadLine());
            int lastNumberMax = int.Parse(Console.ReadLine());

            for (int i = 2; i <= firstNumberMax; i+=2) {
                if (middleNumberMax > 7) { middleNumberMax = 7; }
                for (int j = 2; j <= middleNumberMax; j++) {
                    for (int k = 2; k <= lastNumberMax; k+=2) {
                        Console.WriteLine($"{i} {j} {k}");
                    }
                    if (j >= 3) { j++; }
                }
            }
        }
    }
}
