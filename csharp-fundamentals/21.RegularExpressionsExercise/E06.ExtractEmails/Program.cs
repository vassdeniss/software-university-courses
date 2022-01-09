using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace E06.ExtractEmails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex matcher = new Regex(@"(^|\s)(?<user>[A-Za-z\d]+([_.-]*\w+)+)@(?<host>[A-Za-z]+([.-]\w+)+\b)");
            MatchCollection matches = matcher.Matches(Console.ReadLine());
            matches.ToList().ForEach(Console.WriteLine);
        }
    }
}
