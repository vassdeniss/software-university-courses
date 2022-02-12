using System;
using System.Collections.Generic;
using System.Linq;

namespace E01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split().Skip(1).ToArray();
            ListyIterator<string> listy = new ListyIterator<string>(elements);

            string input = Console.ReadLine();
            while (input != "END")
            {
                if (input == "Move") Console.WriteLine(listy.Move());
                else if (input == "HasNext") Console.WriteLine(listy.HasNext());
                else if (input == "Print") listy.Print();

                input = Console.ReadLine();
            }
        }
    }
}
