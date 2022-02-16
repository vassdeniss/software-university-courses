using System;
using System.Collections.Generic;
using System.Linq;

namespace EP04.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatsArray = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int[] scarfsArray = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            List<int> sets = new List<int>();
            Stack<int> hats = new Stack<int>(hatsArray);
            Queue<int> scarfs = new Queue<int>(scarfsArray);

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Add(hat + scarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }

                if (hat < scarf)
                {
                    hats.Pop();
                }

                if (scarf == hat)
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
