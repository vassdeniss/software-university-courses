using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace E05.NetherRealms
{
    class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Regex healthRegex = new Regex(@"[^\d+\-*\/.]");
            Regex numberRegex = new Regex(@"(?<numbers>[-+]?\d+(\.\d+)?)");
            Regex arithmeticRegex = new Regex(@"[*\/]");
            Regex splitRegex = new Regex(@"[,\s]+");

            string[] demonsInput = splitRegex.Split(Console.ReadLine()).OrderBy(x => x).ToArray();
            List<Demon> demons = new List<Demon>();

            foreach (string demon in demonsInput)
            {
                MatchCollection chars = healthRegex.Matches(demon);
                MatchCollection numbers = numberRegex.Matches(demon);
                MatchCollection arithmetics = arithmeticRegex.Matches(demon);
                int baseHealth = 0;
                double baseDamage = 0;
                foreach (Match m in chars)
                {
                    baseHealth += char.Parse(m.ToString());
                }

                foreach (Match m in numbers)
                {
                    double num = double.Parse(m.ToString());
                    baseDamage += num;
                }

                foreach (Match m in arithmetics)
                {
                    if (m.ToString() == "*") baseDamage *= 2;
                    else baseDamage /= 2;
                }

                demons.Add(new Demon()
                {
                    Name = demon,
                    Health = baseHealth,
                    Damage = baseDamage
                });
            }

            foreach (Demon demon in demons.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }
}
