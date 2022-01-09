using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> racers = 
                Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> racersScore = 
                new Dictionary<string, int>();
            Regex nameMatcher = new Regex(@"(?<letters>[A-Za-z])");
            Regex digitsMatcher = new Regex(@"(?<digits>\d)");

            string input = Console.ReadLine();
            while (input != "end of race")
            {
                StringBuilder nameBuilder = new StringBuilder();
                MatchCollection name = nameMatcher.Matches(input);
                foreach (Match m in name)
                    nameBuilder.Append(m.Value);

                if (racers.Contains(nameBuilder.ToString()))
                {
                    StringBuilder scoreBuilder = new StringBuilder();
                    MatchCollection digits = digitsMatcher.Matches(input);
                    foreach (Match m in digits)
                        scoreBuilder.Append(m.Value);

                    int digitsNum = int.Parse(scoreBuilder.ToString());
                    int score = 0;
                    while (digitsNum > 0)
                    {
                        score += digitsNum % 10;
                        digitsNum /= 10;
                    }

                    if (racersScore.ContainsKey(nameBuilder.ToString()))
                        racersScore[nameBuilder.ToString()] += score;
                    else
                        racersScore.Add(nameBuilder.ToString(), score);
                }

                input = Console.ReadLine();
            }

            int iterator = 0;
            string[] places = { "1st", "2nd", "3rd" };
            foreach (KeyValuePair<string, int> pair in racersScore.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{places[iterator]} place: {pair.Key}");
                iterator++;
                if (iterator > 2) break;
            }
        }
    }
}
