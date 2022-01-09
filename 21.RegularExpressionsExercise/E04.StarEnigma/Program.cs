using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace E04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> planets = new Dictionary<string, char>();

            int messageQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < messageQty; i++)
            {
                AddInformation(planets, DecryptMessage(Console.ReadLine()));
            }

            Dictionary<string, char> attackedPlanets = 
                planets.Where(x => x.Value == 'A').OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Dictionary<string, char> destroyedPlanets =
                planets.Where(x => x.Value == 'D').OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Print(attackedPlanets, destroyedPlanets);
        }

        static void Print(Dictionary<string, char> aP, Dictionary<string, char> dP)
        {
            Console.WriteLine($"Attacked planets: {aP.Count}");
            if (aP.Count > 0)
            {
                foreach (KeyValuePair<string, char> pair in aP)
                {
                    Console.WriteLine($"-> {pair.Key}");
                }
            }

            Console.WriteLine($"Destroyed planets: {dP.Count}");
            if (dP.Count > 0)
            {
                foreach (KeyValuePair<string, char> pair in dP)
                {
                    Console.WriteLine($"-> {pair.Key}");
                }
            }
        }

        static void AddInformation(Dictionary<string, char> dic, string decryptedMessage)
        {
            Regex pattern = new Regex(@"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<attack>[AD])![^@\-!:>]*->(?<soldiers>\d+)");
            Match match = pattern.Match(decryptedMessage);

            if (match.Success)
            {
                string planetName = match.Groups["planet"].Value;
                char attackType = char.Parse(match.Groups["attack"].Value);

                if (!dic.ContainsKey(planetName))
                    dic.Add(planetName, attackType);
            }
        }

        static string DecryptMessage(string encryptedMessage)
        {
            StringBuilder sb = new StringBuilder();
            Regex pattern = new Regex(@"[star]", RegexOptions.IgnoreCase);
            MatchCollection matches = pattern.Matches(encryptedMessage); 

            int count = matches.Count;
            foreach (char c in encryptedMessage)
                sb.Append((char)(c - count));

            return sb.ToString();
        }
    }
}
