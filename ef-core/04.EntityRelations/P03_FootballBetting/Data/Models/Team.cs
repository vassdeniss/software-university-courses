using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(2048)")]
        public string LogoUrl { get; set; }

        [Column(TypeName = "char(3)")]
        public string Initials { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }

        [InverseProperty(nameof(Game.HomeTeam))]
        public ICollection<Game> HomeGames { get; set; }

        [InverseProperty(nameof(Game.AwayTeam))]
        public ICollection<Game> AwayGames { get; set; }
    }
}
