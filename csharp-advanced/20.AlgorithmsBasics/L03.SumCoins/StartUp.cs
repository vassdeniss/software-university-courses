namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine()
                .Split(", ").Select(int.Parse).OrderByDescending(x => x).ToList();
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

            Console.WriteLine(target > 0
                ? "Error"
                : $"Number of coins to take: {coinsQty}\n{sb}");
        }
    }
}
