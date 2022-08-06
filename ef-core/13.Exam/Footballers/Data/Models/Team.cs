using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        [Range(typeof(int), "1", "2147483647")]
        public int Trophies { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
