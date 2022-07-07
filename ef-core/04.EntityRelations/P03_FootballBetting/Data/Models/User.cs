using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}
