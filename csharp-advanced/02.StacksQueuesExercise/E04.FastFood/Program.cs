using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            int[] inputOrders = Console.ReadLine()
                .Split().Select(int.Parse) .ToArray();
            Queue<int> orders = new Queue<int>(inputOrders);

            Console.WriteLine(orders.Max());
            while (orders.Count > 0)
            {
                int order = orders.Peek();
                if (foodQty < order) break;
                foodQty -= order;
                orders.Dequeue();
            }

            Console.WriteLine(orders.Count > 0 ? $"Orders left: {string.Join(" ", orders)}" : "Orders complete");
        }
    }
}
