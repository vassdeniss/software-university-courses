// ReSharper disable RedundantNameQualifier
namespace PetStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PetStore.Data.Common.Models;
    using PetStore.Data.Models.Common;

    public class ClientCard : BaseDeletableModel<string>
    {
        public ClientCard()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(ClientCardValidationConstants.CardNumberMaxLength)]
        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Discount { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
