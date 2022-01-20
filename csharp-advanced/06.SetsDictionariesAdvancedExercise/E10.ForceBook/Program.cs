using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> force = new Dictionary<string, HashSet<string>>();

            string cmd = Console.ReadLine();
            while (cmd != "Lumpawaroo")
            {
                if (cmd.Contains('|'))
                {
                    string[] parts = cmd.Split(" | ");
                    string side = parts[0];
                    string user = parts[1];

                    if (!force.ContainsKey(side)) force.Add(side, new HashSet<string>());

                    if (!force[side].Contains(user) && !force.Values.Any(set => set.Contains(user)))
                        force[side].Add(user);
                }
                else if (cmd.Contains("->"))
                {
                    string[] parts = cmd.Split(" -> ");
                    string user = parts[0];
                    string side = parts[1];

                    if (force.Values.Any(set => set.Contains(user)))
                    {
                        foreach (KeyValuePair<string, HashSet<string>> pair in
                            force.Where(set => set.Value.Contains(user)))
                                pair.Value.Remove(user);
                    }

                    if (!force.ContainsKey(side)) force.Add(side, new HashSet<string>());
                    force[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }

                cmd = Console.ReadLine();
            }

            foreach (KeyValuePair<string, HashSet<string>> pair
                in force.OrderByDescending(list => list.Value.Count).ThenBy(name => name.Key))
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {pair.Key}, Members: {pair.Value.Count}");
                    foreach (string name in pair.Value.OrderBy(name => name))
                        Console.WriteLine($"! {name}");
                }
            }
        }
    }
}
