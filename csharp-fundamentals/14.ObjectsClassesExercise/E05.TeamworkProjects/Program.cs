using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.TeamworkProjects
{
    class Team
    {
        public List<string> Members { get; set; }
        public string Leader { get; set; }
        public string Name { get; set; }

        public Team() => Members = new List<string>();

        public void RegisterTeams(List<Team> teams, int num)
        {
            for (int i = 0; i < num; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-");
                string teamLeader = teamInfo[0];
                string teamName = teamInfo[1];

                if (teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Leader == teamLeader))
                {
                    Console.WriteLine($"{teamLeader} cannot create another team!");
                }
                else
                {
                    teams.Add(new Team()
                    {
                        Leader = teamLeader,
                        Name = teamName,
                        Members = new List<string>()
                    });
                    Console.WriteLine($"Team {teamName} has been created by {teamLeader}!");
                }
            }
        }

        public void PrintTeams(List<Team> teams)
        {
            foreach (Team team in teams.OrderByDescending(team => team.Members.Count)
                .ThenBy(team => team.Name)
                .Where(team => team.Members.Count > 0))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Leader}");
                foreach (string member in team.Members.OrderBy(member => member))
                {
                    Console.WriteLine($"-- {member}");
                }
            } 
        }

        public void DisbandEmptyTeams(List<Team> teams)
        {
            Console.WriteLine("Teams to disband:");
            foreach (Team team in teams.OrderBy(team => team.Name).Where(team => team.Members.Count == 0))
            {
                Console.WriteLine(team.Name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int teamQty = int.Parse(Console.ReadLine());

            List<Team> teamList = new List<Team>();
            Team teamHandler = new Team();
            teamHandler.RegisterTeams(teamList, teamQty);

            string[] cmd = Console.ReadLine().Split("->");
            while (cmd[0] != "end of assignment")
            {
                string memberName = cmd[0];
                string teamName = cmd[1];

                if (!teamList.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teamList.Any(team => team.Leader == memberName)
                            || teamList.Any(team => team.Members.Contains(memberName)))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }
                else
                {
                    Team wantedTeam = teamList.Find(team => team.Name == teamName);
                    wantedTeam.Members.Add(memberName);
                }

                cmd = Console.ReadLine().Split("->");
            }

            teamHandler.PrintTeams(teamList);
            teamHandler.DisbandEmptyTeams(teamList);
        }
    }
}
