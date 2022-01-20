using System;
using System.Collections.Generic;

namespace E01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();

            int qty = int.Parse(Console.ReadLine());
            for (int i = 0; i < qty; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (string name in uniqueNames) Console.WriteLine(name);
        }
    }
}
