using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Footballers.Data.Models.Enums;

namespace Footballers.Data.Models
{
    public class Footballer
    {
        public Footballer()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public DateTime ContractStartDate { get; set; }

        [Required]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public PositionType PositionType { get; set; }

        [Required]
        public BestSkillType BestSkillType { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachId { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
