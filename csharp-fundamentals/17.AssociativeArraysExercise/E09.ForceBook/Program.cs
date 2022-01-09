using System;
using System.Collections.Generic;
using System.Linq;

namespace E09.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceDictionary = new Dictionary<string, List<string>>();

            string cmd = Console.ReadLine();
            while (cmd != "Lumpawaroo")
            {
                if (cmd.Contains('|'))
                {
                    string[] parts = cmd.Split(" | ");

                    string side = parts[0];
                    string user = parts[1];

                    ContainsSide(forceDictionary, side);
                    if (!forceDictionary[side].Contains(user) && !forceDictionary.Values.Any(list => list.Contains(user))) 
                    {
                        forceDictionary[side].Add(user);
                    }
                }
                else if (cmd.Contains("->"))
                {
                    string[] parts = cmd.Split(" -> ");

                    string user = parts[0];
                    string side = parts[1];

                    if (!forceDictionary.Values.Any(list => list.Contains(user)))
                    {
                        ContainsSide(forceDictionary, side);
                        forceDictionary[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        foreach (KeyValuePair<string, List<string>> pair in forceDictionary
                            .Where(list => list.Value.Contains(user)))
                        {
                            pair.Value.Remove(user);
                        }

                        ContainsSide(forceDictionary, side);
                        forceDictionary[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }

                cmd = Console.ReadLine();
            }

            Print(forceDictionary);
        }

        static void Print(Dictionary<string, List<string>> dic)
        {
            foreach (KeyValuePair<string, List<string>> pair in dic.OrderByDescending(list => list.Value.Count).ThenBy(name => name.Key))
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {pair.Key}, Members: {pair.Value.Count}");
                    foreach (string name in pair.Value.OrderBy(name => name))
                        Console.WriteLine($"! {name}");
                }
            }
        }

        static void ContainsSide(Dictionary<string, List<string>> dic, string side)
        {
            if (!dic.ContainsKey(side))
            {
                dic.Add(side, new List<string>());
            }
        }
    }
}
