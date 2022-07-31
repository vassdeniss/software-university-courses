// ReSharper disable RedundantNameQualifier
namespace PetStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PetStore.Data.Common.Models;
    using PetStore.Data.Models.Common;

    public class CardInfo : BaseDeletableModel<string>
    {
        public CardInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(CardInfoValidationConstants.CardNumberMaxLength)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.ExpirationDateMaxLength)]
        public string ExpirationDate { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.CardHolderMaxLength)]
        public string CardHolder { get; set; }

        // ReSharper disable once InconsistentNaming
        [Required]
        [MaxLength(CardInfoValidationConstants.CVCMaxLength)]
        public string CVC { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
