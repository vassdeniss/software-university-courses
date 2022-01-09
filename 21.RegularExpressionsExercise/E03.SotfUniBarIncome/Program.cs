using System;
using System.Text;
using System.Text.RegularExpressions;

namespace E03.SotfUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex matcher = new Regex(@"%(?<name>[A-Z][a-z]+)%[^%$|.]*<(?<product>\w+)>[^%$|.]*\|(?<qty>\d+)\|[^%$|.]*?(?<price>\d+|\d+\.\d+)\$");
            string input = Console.ReadLine();
            decimal total = 0;

            StringBuilder sb = new StringBuilder();
            while (input != "end of shift")
            {
                Match match = matcher.Match(input);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value) * int.Parse(match.Groups["qty"].Value);

                    total += price;
                    sb.AppendLine($"{name}: {product} - {price:f2}");
                }

                input = Console.ReadLine();
            }

            sb.AppendLine($"Total income: {total:f2}");
            Console.WriteLine(sb);
        }
    }
}
