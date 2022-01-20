using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.TheVLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers 
                = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] data = input.Split();

                if (data[1] == "joined" && !vloggers.ContainsKey(data[0]))
                {
                    vloggers.Add(data[0], new Dictionary<string, HashSet<string>>());
                    vloggers[data[0]].Add("followers", new HashSet<string>());
                    vloggers[data[0]].Add("following", new HashSet<string>());
                }

                if (data[1] == "followed" && vloggers.ContainsKey(data[0]) 
                    && vloggers.ContainsKey(data[2]) && data[0] != data[2])
                {
                    vloggers[data[0]]["following"].Add(data[2]);
                    vloggers[data[2]]["followers"].Add(data[0]);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            int iterator = 0;
            foreach (KeyValuePair<string, Dictionary<string, HashSet<string>>> vlogger in vloggers
                .OrderByDescending(x => x.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{++iterator}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (iterator == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
