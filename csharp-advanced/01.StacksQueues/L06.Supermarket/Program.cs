using System;
using System.Collections.Generic;

namespace L06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> personQueue = new Queue<string>();

            string name = Console.ReadLine();
            while (name != "End")
            {
                if (name == "Paid")
                {
                    while (personQueue.Count > 0)
                    {
                        Console.WriteLine(personQueue.Dequeue());
                    }

                    name = Console.ReadLine();
                    continue;
                }

                personQueue.Enqueue(name);
                name = Console.ReadLine();
            }

            Console.WriteLine($"{personQueue.Count} people remaining.");
        }
    }
}
