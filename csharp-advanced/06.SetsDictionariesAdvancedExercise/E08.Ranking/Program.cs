using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] cmd = input.Split(':');
                string contest = cmd[0];
                string password = cmd[1];

                if (!contests.ContainsKey(contest)) contests.Add(contest, password);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] cmd = input.Split("=>");

                string contest = cmd[0];
                string password = cmd[1];
                string username = cmd[2];
                int points = int.Parse(cmd[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                        users.Add(username, new Dictionary<string, int>() { { contest, points } });

                    if (!users[username].ContainsKey(contest))
                        users[username].Add(contest, points);

                    if (points > users[username][contest])
                        users[username][contest] = points;
                }

                input = Console.ReadLine();
            }

            Print(users);
        }

        static void Print(Dictionary<string, Dictionary<string, int>> dic)
        {
            string bestCandidate = string.Empty;
            int bestPoints = 0;
            foreach (string name in dic.Keys)
            {
                int totalPoints = dic[name].Values.Sum();

                if (totalPoints > bestPoints)
                {
                    bestPoints = totalPoints;
                    bestCandidate = name;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPoints} points.");
            Console.WriteLine("Ranking: ");
            foreach (string name in dic.Keys.OrderBy(name => name))
            {
                Console.WriteLine(name);
                foreach (KeyValuePair<string, int> pair in dic[name].OrderByDescending(points => points.Value))
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}
