using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L07.SumCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ").Select(int.Parse).OrderByDescending(x => x).ToList();
            int target = int.Parse(Console.ReadLine());

            int coinsQty = 0;
            StringBuilder sb = new StringBuilder();
            while (target > 0 && coins.Count > 0)
            {
                int coin = coins.First();
                int possibleCoins = target / coin;

                target -= coin * possibleCoins;
                coinsQty += possibleCoins;
                coins.Remove(coin);
                if (possibleCoins > 0) sb.AppendLine($"{possibleCoins} coin(s) with value {coin}");
            }

            if (target > 0) Console.WriteLine("Error");
            else
            {
                Console.WriteLine($"Number of coins to take: {coinsQty}");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
