using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace E01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            decimal totalMoney = 0;
            List<string> furniture = new List<string>();

            Regex matcher = new Regex(@">>(?<item>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<qty>\d+)");
            while (input != "Purchase")
            {
                Match match = matcher.Match(input);

                if (match.Success)
                {
                    string item = match.Groups["item"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int qty = int.Parse(match.Groups["qty"].Value);

                    furniture.Add(item);
                    totalMoney += price * qty;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (string s in furniture)
                Console.WriteLine(s);
            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}
