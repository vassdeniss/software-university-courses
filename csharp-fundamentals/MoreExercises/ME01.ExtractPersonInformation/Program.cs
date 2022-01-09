using System;

namespace ME01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesQty; i++)
            {
                string input = Console.ReadLine();
                int atSymbol = input.IndexOf('@');
                int pipeSymbol = input.IndexOf('|');
                int hashSymbol = input.IndexOf('#');
                int starSymbol = input.IndexOf('*');

                string name = input[(atSymbol + 1)..pipeSymbol];
                string age = input[(hashSymbol + 1)..starSymbol];

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
