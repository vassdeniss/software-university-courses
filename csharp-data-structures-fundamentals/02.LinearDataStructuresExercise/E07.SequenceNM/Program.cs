using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.SequenceNM
{
    class Item
    {
        public Item(int value, Item prev)
        {
            Value = value;
            Previous = prev;
        }

        public int Value { get; private set; }
        public Item Previous { get; private set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            Queue<Item> queue = new Queue<Item>();

            int m = nums[1];
            queue.Enqueue(new Item(nums[0], null));
            while (queue.Count > 0)
            {
                Item n = queue.Dequeue();
                if (n.Value < m)
                {
                    queue.Enqueue(new Item(n.Value + 1, n));
                    queue.Enqueue(new Item(n.Value + 2, n));
                    queue.Enqueue(new Item(n.Value * 2, n));
                }

                if (n.Value == m)
                {
                    Stack<int> stack = new Stack<int>();

                    while (n != null)
                    {
                        stack.Push(n.Value);
                        n = n.Previous;
                    }

                    Console.WriteLine(string.Join(" -> ", stack));
                    break;
                }
            }
        }
    }
}
