using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name) : this()
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                Validator<string>.ValidateData(ValidationType.NAME, value);
                name = value;
            }
        }

        public int Rating =>
            players.Any()
            ? (int)Math.Round(players.Average(x => x.Stats))
            : 0;

        public IReadOnlyCollection<Player> Players => players.AsReadOnly();

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            Validator<Player>.ValidateData(ValidationType.PLAYER, player, null, this.name, name);

            players.Remove(player); 
        }
    }
}
