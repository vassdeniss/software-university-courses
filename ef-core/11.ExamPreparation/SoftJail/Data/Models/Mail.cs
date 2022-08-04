using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [ForeignKey(nameof(Prisoner))]
        public int PrisonerId { get; set; }

        public virtual Prisoner Prisoner { get; set; }
    }
}
