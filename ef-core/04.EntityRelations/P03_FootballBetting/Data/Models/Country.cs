using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; }
    }
}
