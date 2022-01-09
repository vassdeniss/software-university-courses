using System;
using System.Collections.Generic;
using System.Linq;

namespace ME04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dwarfDictionary = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] cmd = input.Split(" <:> ");

                string dwarfName = cmd[0];
                string dwarfHatColor = cmd[1];
                int dwarfPhysics = int.Parse(cmd[2]);

                string identifier = $"{dwarfName}:{dwarfHatColor}";
                if (!dwarfDictionary.ContainsKey(identifier))
                {
                    dwarfDictionary.Add(identifier, dwarfPhysics);
                }
                else dwarfDictionary[identifier] = Math.Max(dwarfDictionary[identifier], dwarfPhysics);

                input = Console.ReadLine();
            }
            
            foreach (KeyValuePair<string, int> pair in dwarfDictionary
                .OrderByDescending(x => x.Value)
                .ThenByDescending(x => dwarfDictionary.Where(y => y.Key.Split(':')[1] == x.Key.Split(':')[1]).Count()))
            {
                Console.WriteLine($"({pair.Key.Split(':')[1]}) {pair.Key.Split(':')[0]} <-> {pair.Value}");
            }
        }
    }
}
