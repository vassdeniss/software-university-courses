using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace L02.MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phones = Console.ReadLine();

            Regex pattern = new Regex(@"\+359(?<seperators>[ -])2\k<seperators>[0-9]{3}\k<seperators>[0-9]{4}\b");
            MatchCollection matches = pattern.Matches(phones);

            string[] matchedPhones = matches.Select(x => x.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
