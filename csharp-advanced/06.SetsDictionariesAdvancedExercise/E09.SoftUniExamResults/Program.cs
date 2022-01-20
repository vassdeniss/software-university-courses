using System;
using System.Collections.Generic;
using System.Linq;

namespace E09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> languages = new Dictionary<string, int>();
            Dictionary<string, int> users = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] cmd = input.Split('-');
                string username = cmd[0];
                string language = cmd[1];

                if (language == "banned" && users.ContainsKey(username))
                {
                    users.Remove(username);
                    input = Console.ReadLine();
                    continue;
                }

                int points = int.Parse(cmd[2]);

                if (!languages.ContainsKey(language)) languages.Add(language, 0);
                languages[language]++;

                if (!users.ContainsKey(username)) users.Add(username, points);
                else if (points > users[username]) users[username] = points;

                input = Console.ReadLine();
            }

            Print(users, languages);
        }

        static void Print(Dictionary<string, int> users,
                          Dictionary<string, int> languages)
        {
            Console.WriteLine("Results:");
            foreach (KeyValuePair<string, int> pair in users
                .OrderByDescending(points => points.Value).ThenBy(user => user.Key))
            {
                Console.WriteLine($"{pair.Key} | {pair.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (KeyValuePair<string, int> pair in languages
                .OrderByDescending(points => points.Value).ThenBy(user => user.Key))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}
