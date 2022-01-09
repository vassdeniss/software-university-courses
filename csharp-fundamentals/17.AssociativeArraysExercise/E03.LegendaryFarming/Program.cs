using System;
using System.Collections.Generic;
using System.Linq;

namespace E03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materialDictionary = new Dictionary<string, int>
            {
                { "shards", 0 }, { "fragments", 0 }, { "motes", 0 }
            };
            Dictionary<string, int> junkDictionary = new Dictionary<string, int>();

            string sword = string.Empty;
            bool isFound = false;
            while (!isFound)
            {
                string[] input = Console.ReadLine().Split();
                for (int i = 0; i < input.Length; i += 2)
                {
                    int value = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();
                    if (material == "motes" || material == "fragments" || material == "shards")
                        materialDictionary[material] += value;
                    else
                        AddToJunk(junkDictionary, material, value);

                    if (materialDictionary["shards"] >= 250)
                    {
                        sword = "Shadowmourne";
                        materialDictionary["shards"] -= 250;
                        isFound = true;
                        break;
                    }
                    else if (materialDictionary["fragments"] >= 250)
                    {
                        sword = "Valanyr";
                        materialDictionary["fragments"] -= 250;
                        isFound = true;
                        break;
                    }
                    else if (materialDictionary["motes"] >= 250)
                    {
                        sword = "Dragonwrath";
                        materialDictionary["motes"] -= 250;
                        isFound = true;
                        break;
                    }
                }
            }

            Print(materialDictionary, junkDictionary, sword);
        }

        static void AddToJunk(Dictionary<string, int> dic, string material, int value)
        {
            if (dic.ContainsKey(material)) dic[material] += value;
            else dic.Add(material, value);
        }

        static void Print(Dictionary<string, int> matDic, Dictionary<string, int> junkDic, string item)
        {
            Console.WriteLine($"{item} obtained!");
            foreach (KeyValuePair<string, int> pair in matDic.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            foreach (KeyValuePair<string, int> pair in junkDic.OrderBy(x => x.Key))
                Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
