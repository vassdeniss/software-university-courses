using System;
using System.Collections.Generic;
using System.Linq;

namespace ME01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestDictionary = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> userDictionary = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] cmd = input.Split(':');

                string contest = cmd[0];
                string password = cmd[1];

                if (!contestDictionary.ContainsKey(contest)) contestDictionary.Add(contest, password);

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

                RegisterSubmission(contestDictionary, userDictionary, contest, password, username, points);

                input = Console.ReadLine();
            }

            Print(userDictionary);
        }

        static void RegisterSubmission(Dictionary<string, string> contestDictionary,
                                       Dictionary<string, Dictionary<string, int>> userDictionary,
                                       string contest,
                                       string password,
                                       string username,
                                       int points)
        {
            if (contestDictionary.ContainsKey(contest))
            {
                if (contestDictionary[contest] == password)
                {
                    if (userDictionary.ContainsKey(username))
                    {
                        if (userDictionary[username].ContainsKey(contest))
                        {
                            if (points > userDictionary[username][contest])
                            {
                                userDictionary[username][contest] = points;
                            }
                        }
                        else
                        {
                            userDictionary[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        userDictionary.Add(username, new Dictionary<string, int>()
                        {
                            {contest, points}
                        });
                    }
                }
            }
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
