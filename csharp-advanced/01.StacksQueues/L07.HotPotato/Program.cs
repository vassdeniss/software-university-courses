using System;
using System.Collections.Generic;

namespace L07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());

            int passesQty = int.Parse(Console.ReadLine());
            int passes = passesQty;
            while (kids.Count > 1)
            {
                if (--passes <= 0)
                {
                    Console.WriteLine($"Removed {kids.Dequeue()}");
                    passes = passesQty;
                    continue;
                } 

                kids.Enqueue(kids.Dequeue());
            }

            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
