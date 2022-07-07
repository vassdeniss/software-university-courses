using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        public int SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
