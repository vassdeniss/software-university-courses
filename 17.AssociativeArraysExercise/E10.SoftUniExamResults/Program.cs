using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languageDictionary = new Dictionary<string, int>();
            Dictionary<string, int> userDictionary = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] cmd = input.Split('-');

                string username = cmd[0];
                string language = cmd[1];

                if (language == "banned")
                {
                    if (userDictionary.ContainsKey(username)) userDictionary.Remove(username);
                }
                else
                {
                    int points = int.Parse(cmd[2]);

                    if (!languageDictionary.ContainsKey(language))
                        languageDictionary.Add(language, 1);
                    else
                        languageDictionary[language]++;

                    if (!userDictionary.ContainsKey(username))
                    {
                        userDictionary.Add(username, points);
                    }
                    else
                    {
                        if (points > userDictionary[username])
                        {
                            userDictionary[username] = points;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Print(userDictionary, languageDictionary);
        }

        static void Print(Dictionary<string, int> userDictionary,
                          Dictionary<string, int> languageDictionary)
        {
            Console.WriteLine("Results:");
            foreach (KeyValuePair<string, int> pair in userDictionary
                .OrderByDescending(points => points.Value)
                .ThenBy(user => user.Key))
            {
                Console.WriteLine($"{pair.Key} | {pair.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (KeyValuePair<string, int> pair in languageDictionary
                .OrderByDescending(points => points.Value)
                .ThenBy(user => user.Key))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
