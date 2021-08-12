using System;

namespace BE05.ChallengeTheWedding {
    class Program {
        static void Main(string[] args) {
            int maleQty = int.Parse(Console.ReadLine());
            int womanQty = int.Parse(Console.ReadLine());
            int tableQty = int.Parse(Console.ReadLine());

            for (int i = 1; i <= maleQty; i++) {
                for (int j = 1; j <= womanQty; j++) {
                    if (tableQty == 0) { return; }
                    tableQty--;
                    Console.Write($"({i} <-> {j}) ");
                }
            }
        }
    }
}
