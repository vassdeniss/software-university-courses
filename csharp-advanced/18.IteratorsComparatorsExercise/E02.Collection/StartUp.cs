using System;
using System.Linq;
using System.Text;

namespace E02.Collection
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
                else if (input == "PrintAll")
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string element in elements) sb.Append($"{element} ");
                    Console.WriteLine(sb);
                }

                input = Console.ReadLine();
            }
        }
    }
}
