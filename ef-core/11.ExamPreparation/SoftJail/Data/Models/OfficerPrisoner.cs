using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [Required]
        public int PrisonerId { get; set; }

        public virtual Prisoner Prisoner { get; set; }

        [Required]
        public int OfficerId { get; set; }

        public virtual Officer Officer { get; set; }
    }
}
