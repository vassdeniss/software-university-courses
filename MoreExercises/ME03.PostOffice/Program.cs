using System;
using System.Text.RegularExpressions;

namespace ME03.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex firstPattern = new Regex(@"(?<symbol>[#$%*&])(?<letters>[A-Z]+)[a-z]*?\k<symbol>");

            string[] input = Console.ReadLine().Split('|');

            string firstPart = input[0];
            string secondPart = input[1];
            string thirdPart = input[2];

            Match firstMatch = firstPattern.Match(firstPart);

            string capitals = firstMatch.Groups["letters"].Value;
            foreach (char c in capitals)
            {
                Regex secondPattern = new Regex($@"(?<ascii>{(int)c}):(?<lenght>\d{{2}})");
                Match secondMatch = secondPattern.Match(secondPart);
                int lenght = int.Parse(secondMatch.Groups["lenght"].Value);

                Regex thirdPattern = new Regex($@"(?<!\S){c}.{{{lenght}}}(?!\S)");
                Match thirdMatch = thirdPattern.Match(thirdPart);

                Console.WriteLine(thirdMatch.ToString());
            }
        }
    }
}
