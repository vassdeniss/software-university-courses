using System;
using System.Collections.Generic;
using System.Linq;

namespace ME02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userDictionary = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> userBestDictionary = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] cmd = input.Split(" -> ");

                string username = cmd[0];
                string contest = cmd[1];
                int points = int.Parse(cmd[2]);

                if (userDictionary.ContainsKey(contest))
                {
                    if (userDictionary[contest].ContainsKey(username))
                    {
                        if (points > userDictionary[contest][username])
                        {
                            userBestDictionary[username] -= userDictionary[contest][username];
                            userDictionary[contest][username] = points;
                            userBestDictionary[username] += userDictionary[contest][username];
                        }
                    }
                    else
                    {
                        if (!userBestDictionary.ContainsKey(username))
                        {
                            userBestDictionary.Add(username, points);
                        }
                        else
                        {
                            userBestDictionary[username] += points;
                        }
                        userDictionary[contest].Add(username, points);
                    }
                }
                else
                {
                    if (!userBestDictionary.ContainsKey(username))
                    {
                        userBestDictionary.Add(username, points);
                    }
                    else
                    {
                        userBestDictionary[username] += points;
                    }
                    userDictionary.Add(contest, new Dictionary<string, int>()
                    {
                        {username, points}
                    });
                }

                input = Console.ReadLine();
            }

            Print(userDictionary, userBestDictionary);
        }

        private static void Print(Dictionary<string, Dictionary<string, int>> userDictionary,
                                  Dictionary<string, int> bestDictionary)
        {
            int iterator = 1;

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in userDictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Count()} participants");

                iterator = 1;
                foreach (KeyValuePair<string, int> user in pair.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{iterator}. {user.Key} <::> {user.Value}");
                    iterator++;
                }
            }

            Console.WriteLine("Individual standings:");

            iterator = 1;
            foreach (KeyValuePair<string, int> user in bestDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{iterator}. {user.Key} -> {user.Value}");
                iterator++;
            }
        }
    }
}
