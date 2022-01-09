using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ME02.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex extractNumbers = new Regex(@"\d+");
            Regex extractCharacters = new Regex(@"[^\d]+");
            string input = Console.ReadLine();

            string[] nums = extractNumbers.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();
            string[] chars = extractCharacters.Matches(input).Cast<Match>().Select(m => m.Value).ToArray();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < chars.Length; i++)
            {
                sb.Append(string.Concat(Enumerable.Repeat(chars[i].ToUpper(), int.Parse(nums[i]))));
            }
            Console.WriteLine($"Unique symbols used: {CountUniqueChars(chars, nums)}");
            Console.WriteLine(sb);
        }

        static int CountUniqueChars(string[] charsArr, string[] numsArr)
        {
            List<char> chars = new List<char>();
            for (int i = 0; i < charsArr.Length; i++)
            {
                if (int.Parse(numsArr[i]) > 0)
                {
                    char[] symbols = charsArr[i].ToCharArray();
                    foreach (char c in symbols)
                    {
                        char addChar = char.ToLower(c);
                        if (!chars.Contains(addChar))
                        {
                            chars.Add(addChar);
                        }
                    }
                }
            }
            return chars.Count();
        }
    }
}
