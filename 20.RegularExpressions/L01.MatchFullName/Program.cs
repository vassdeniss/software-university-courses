using System;
using System.Text.RegularExpressions;

namespace L01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            Regex pattern = new Regex(@"\b[A-Z][a-z]+ [A-Z][a-z]+");

            MatchCollection matches = pattern.Matches(names);
            foreach (Match match in matches)
                Console.Write($"{match.Value} ");
        }
    }
}
