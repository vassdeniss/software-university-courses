using System;
using System.Linq;

namespace RodCutting
{
    public class StartUp
    {
        private static int[] bestPrices;
        private static int[] combos;

        public static void Main()
        {
            int[] prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int length = int.Parse(Console.ReadLine());

            bestPrices = new int[length + 1];
            combos = new int[length + 1];

            Console.WriteLine(CutRod(prices, length));

            while (length != 0)
            {
                Console.Write($"{combos[length]} ");
                length -= combos[length];
            }
        }

        private static int CutRod(int[] prices, int length)
        {
            if (length == 0)
            {
                return 0;
            }

            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            int bestPrice = prices[length];
            int bestCombo = length;
            for (int i = 1; i < length; i++)
            {
                int currentPrice = prices[i] + CutRod(prices, length - i);
                if (currentPrice > bestPrice)
                {
                    bestPrice = currentPrice;
                    bestCombo = i;
                }
            }

            bestPrices[length] = bestPrice;
            combos[length] = bestCombo;

            return bestPrice;
        }
    }
}
