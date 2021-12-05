using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EXAM02.MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex matcher = new Regex(@"(!)(?<command>[A-Z][a-z]{3,})\1:\[(?<string>[A-Za-z]{8,})\]");
            
            int messageQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < messageQty; i++)
            {
                string message = Console.ReadLine();
                if (matcher.IsMatch(message))
                {
                    Match match = matcher.Match(message);
                    List<int> asciiNums = new List<int>();

                    string messageString = match.Groups["string"].Value;
                    foreach (char c in messageString) asciiNums.Add(c);
                    Console.WriteLine($"{match.Groups["command"].Value}: {string.Join(' ', asciiNums)}");
                }
                else Console.WriteLine("The message is invalid");
            }
        }
    }
}
