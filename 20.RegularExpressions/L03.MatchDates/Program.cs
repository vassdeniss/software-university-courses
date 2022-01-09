using System;
using System.Text.RegularExpressions;

namespace L03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\b(?<day>\d{2})(?<seperator>[-.\/])(?<month>[A-Z][a-z]+)\k<seperator>(?<year>\d{4})");
            string dates = Console.ReadLine();

            MatchCollection matches = pattern.Matches(dates);
            foreach (Match match in matches)
            {
                string day = match.Groups["day"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
