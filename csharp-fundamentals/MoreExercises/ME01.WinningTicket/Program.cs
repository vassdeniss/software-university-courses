using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ME01.WinningTicket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex check = new Regex(@"(?=.{20}).*?(?=(?<symbol>[@#$^]))(?<match>\k<symbol>{6,}).*(?<=.{10})\k<match>.*");

            List<string> tickets = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList(); 
            foreach (string ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    Match match = check.Match(ticket);
                    if (match.Success)
                    {
                        string matchString = match.Groups["match"].ToString();
                        string result = matchString.Length == 10 ? "jackpot" : "match";
                        PrintResult(result, ticket, matchString[0], matchString.Length);
                    }
                    else
                    {
                        PrintResult("no-match", ticket);
                    }
                }
                else
                {
                    PrintResult("invalid");
                }
            }
        }

        static void PrintResult(string result,
                                string ticket = "",
                                char symbol = 'a',
                                int length = 0)
        {
            switch (result)
            {
                case "invalid":
                    Console.WriteLine("invalid ticket");
                    return;
                case "no-match":
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    break;
                case "match":
                    Console.WriteLine($"ticket \"{ticket}\" - {length}{symbol}");
                    break;
                case "jackpot":
                    Console.WriteLine($"ticket \"{ticket}\" - {length}{symbol} Jackpot!");
                    break;
            }
        }
    }
}
