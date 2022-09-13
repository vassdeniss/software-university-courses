using System;
using System.Collections.Generic;

namespace Knapsack
{
    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }

    public class StartUp
    {
        public static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            List<Item> items = ReadItems();

            int[,] dp = new int[items.Count + 1, maxCapacity + 1];
            bool[,] included = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                Item currentItem = items[row - 1];
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int skip = dp[row - 1, capacity];
                    if (currentItem.Weight > capacity)
                    {
                        dp[row, capacity] = skip;
                        continue;
                    }

                    int take = currentItem.Value + dp[row - 1, capacity - currentItem.Weight];
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

            SortedSet<string> includedItems = new SortedSet<string>();

            int totalValue = dp[items.Count, maxCapacity];
            int totalWeight = 0;
            for (int row = included.GetLength(0) - 1; row >= 0; row--)
            {
                if (!included[row, maxCapacity])
                {
                    continue;
                }

                Item includedItem = items[row - 1];
                maxCapacity -= includedItem.Weight;
                totalWeight += includedItem.Weight;
                includedItems.Add(includedItem.Name);
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            foreach (string itemName in includedItems)
            {
                Console.WriteLine(itemName);
            }
        }

        private static List<Item> ReadItems()
        {
            List<Item> result = new List<Item>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] itemData = line.Split();
                result.Add(new Item
                {
                    Name = itemData[0],
                    Weight = int.Parse(itemData[1]),
                    Value = int.Parse(itemData[2]),
                });
            }

            return result;
        }
    }
}
