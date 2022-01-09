using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace O02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            Regex wordMatcher = new Regex(@"([@#])(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1");

            string input = Console.ReadLine();
            if (wordMatcher.IsMatch(input))
            {
                MatchCollection matches = wordMatcher.Matches(input);
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match match in matches)
                {
                    string wordOne = match.Groups["wordOne"].Value;
                    string s = match.Groups["wordTwo"].Value;

                    char[] charArray = s.ToCharArray();
                    Array.Reverse(charArray);
                    string wordTwo = new string(charArray);

                    if (wordOne == wordTwo) mirrorWords.Add(wordOne, s);
                }
            }
            else Console.WriteLine("No word pairs found!");

            if (mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }

            int iterator = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The mirror words are:");
            foreach (KeyValuePair<string, string> pair in mirrorWords)
            {
                sb.Append($"{pair.Key} <=> {pair.Value}");
                if (iterator < mirrorWords.Count) sb.Append(", ");
                iterator++;
            }
            Console.WriteLine(sb);
        }
    }
}
