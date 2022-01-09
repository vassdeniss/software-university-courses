using System;
using System.Text;
using System.Text.RegularExpressions;

namespace EP02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(?<symbol>[=\/])(?<name>[A-Z][A-Za-z]{2,})\k<symbol>");
            MatchCollection matches = pattern.Matches(Console.ReadLine());

            int travelPoints = 0;
            foreach (Match match in matches)
                travelPoints += match.Groups["name"].Value.Length;

            StringBuilder sb = new StringBuilder();
            sb.Append("Destinations: ");
            for (int i = 0; i < matches.Count; i++)
            {
                sb.Append(matches[i].Groups["name"].Value);
                if (i != matches.Count - 1) sb.Append(", ");
            }

            sb.Append($"\nTravel Points: {travelPoints}");
            Console.WriteLine(sb);
        }
    }
}
