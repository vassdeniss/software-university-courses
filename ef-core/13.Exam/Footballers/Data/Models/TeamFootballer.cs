using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class TeamFootballer
    {
        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        [Required]
        public int FootballerId { get; set; }

        public virtual Footballer Footballer { get; set; }
    }
}
