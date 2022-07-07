using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace P03_FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int PositionId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
