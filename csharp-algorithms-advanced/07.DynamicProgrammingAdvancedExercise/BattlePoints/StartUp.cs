using System;
using System.Collections.Generic;
using System.Linq;

namespace BattlePoints
{
    public class Enemy
    {
        public int Weight { get; set; }

        public int Value { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            List<Enemy> enemies = ReadItems();

            int maxEnergy = int.Parse(Console.ReadLine());

            int[,] dp = new int[enemies.Count + 1, maxEnergy + 1];
            bool[,] included = new bool[enemies.Count + 1, maxEnergy + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                Enemy currentEnemy = enemies[row - 1];
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int skip = dp[row - 1, capacity];
                    if (currentEnemy.Weight > capacity)
                    {
                        dp[row, capacity] = skip;
                        continue;
                    }

                    int take = currentEnemy.Value + dp[row - 1, capacity - currentEnemy.Weight];
                    if (take > skip)
                    {
                        dp[row, capacity] = take;
                        included[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = skip;
                    }
                }
            }

            Console.WriteLine(dp[enemies.Count, maxEnergy]);
        }

        private static List<Enemy> ReadItems()
        {
            int[] weights = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] values = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            return weights.Select((t, i) => new Enemy
            {
                Weight = t, Value = values[i]
            }).ToList();
        }
    }
}
