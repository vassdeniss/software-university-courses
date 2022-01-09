using System;
using System.Collections.Generic;
using System.Linq;

namespace ME03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> summonerDictionary 
                = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] cmd = input.Split(" -> ");

                    string player = cmd[0];
                    string position = cmd[1];
                    int skill = int.Parse(cmd[2]);

                    RegisterSkill(summonerDictionary, player, position, skill);
                }
                else if (input.Contains("vs"))
                {
                    string[] cmd = input.Split(" vs ");

                    string player = cmd[0];
                    string enemyPlayer = cmd[1];

                    Versus(summonerDictionary, player, enemyPlayer);
                }

                input = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in summonerDictionary
                .OrderByDescending(skill => skill.Value.Values.Sum()).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Values.Sum()} skill");
                foreach (KeyValuePair<string, int> pos in pair.Value
                    .OrderByDescending(skills => skills.Value).ThenBy(name => name.Key))
                {
                    Console.WriteLine($"- {pos.Key} <::> {pos.Value}");
                }
            }
        }

        static void Versus(Dictionary<string, Dictionary<string, int>> summonerDictionary,
                           string player,
                           string enemyPlayer)
        {
            bool isDuelOver = false;
            if (summonerDictionary.ContainsKey(player) && summonerDictionary.ContainsKey(enemyPlayer))
            {
                foreach (string position in summonerDictionary[player].Keys)
                {
                    foreach (string enemyPosition in summonerDictionary[enemyPlayer].Keys)
                    {
                        if (position == enemyPosition)
                        {
                            int playerSkill = summonerDictionary[player][position];
                            int enemyPlayerSkill = summonerDictionary[enemyPlayer][position];

                            if (playerSkill > enemyPlayerSkill)
                            {
                                summonerDictionary.Remove(enemyPlayer);
                            }
                            else if (playerSkill < enemyPlayerSkill)
                            {
                                summonerDictionary.Remove(player);
                            }

                            isDuelOver = true;
                            break;
                        }
                    }

                    if (isDuelOver) break;
                }
            }
        }

        static void RegisterSkill(Dictionary<string, Dictionary<string, int>> summonerDictionary,
                                  string player,
                                  string position,
                                  int skill)
        {
            if (summonerDictionary.ContainsKey(player))
            {
                if (summonerDictionary[player].ContainsKey(position))
                {
                    if (skill > summonerDictionary[player][position])
                    {
                        summonerDictionary[player][position] = skill;
                    }
                }
                else summonerDictionary[player].Add(position, skill);
            }
            else
            {
                summonerDictionary.Add(player, new Dictionary<string, int>() { {position, skill} });
            }
        }
    }
}
