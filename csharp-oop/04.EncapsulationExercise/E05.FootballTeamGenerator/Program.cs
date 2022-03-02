using System;
using System.Collections.Generic;

namespace E05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split(';');
                if (tokens[0] == "Team")
                {
                    try
                    {
                        Team team = new Team(tokens[1]);
                        teams.Add(tokens[1], team);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (tokens[0] == "Add")
                {
                    if (!teams.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        input = Console.ReadLine();
                        continue;
                    }

                    try 
                    { 
                        teams[tokens[1]].AddPlayer(new Player(tokens[2],
                                                int.Parse(tokens[3]),
                                                int.Parse(tokens[4]),
                                                int.Parse(tokens[5]),
                                                int.Parse(tokens[6]),
                                                int.Parse(tokens[7])));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    try
                    {
                        teams[tokens[1]].RemovePlayer(tokens[2]);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (tokens[0] == "Rating")
                {
                    if (!teams.ContainsKey(tokens[1]))
                    {
                        Console.WriteLine($"Team {tokens[1]} does not exist.");
                        input = Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"{teams[tokens[1]].Name} - {teams[tokens[1]].Rating}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
