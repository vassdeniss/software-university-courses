using System;
using System.Collections.Generic;
using System.Linq;

namespace CableMerchant
{
    public class StartUp
    {
        private static List<int> prices;
        private static int[] bestPrices;
        private static int[] combos;

        public static void Main()
        {
            prices = new List<int> { 0 };

            prices.AddRange(Console.ReadLine()
                .Split()
                .Select(int.Parse)); ;

            bestPrices = new int[prices.Count];
            combos = new int[prices.Count];

            int connectorPrice = int.Parse(Console.ReadLine());

            List<int> result = new List<int>();
            for (int length = 1; length < prices.Count; length++)
            {
                result.Add(CutCable(length, connectorPrice));
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static int CutCable(int length, int connectorPrice)
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
                int currentPrice = prices[i] + CutCable(length - i, connectorPrice) - 2 * connectorPrice;
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
