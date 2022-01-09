using System;

namespace BE10.Profit {
    class Program {
        static void Main(string[] args) {
            int oneLevQty = int.Parse(Console.ReadLine()); 
            int twoLevQty = int.Parse(Console.ReadLine()); 
            int fiveLevQty = int.Parse(Console.ReadLine()); 
            int sum = int.Parse(Console.ReadLine());
            int i = 0;
            int j = 0;
            int k = 0;

            for (i = 0; i <= oneLevQty; i++) {
                j = 0;
                for (j = 0; j <= twoLevQty; j++) {
                    k = 0;
                    for (k = 0; k <= fiveLevQty; k++) {
                        int valueOne = i * 1;
                        int valueTwo = j * 2;
                        int valueThree = k * 5;

                        if (valueOne + valueTwo + valueThree == sum) {
                            Console.WriteLine(
                                $"{i} * 1 lv. " +
                                $"+ {j} * 2 lv. " +
                                $"+ {k} * 5 lv. " +
                                $"= {sum} lv.");
                            break;
                        }
                    }
                }
            }
        }
    }
}
