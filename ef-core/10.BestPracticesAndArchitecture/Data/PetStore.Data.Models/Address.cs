// ReSharper disable RedundantNameQualifier
namespace PetStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PetStore.Data.Common.Models;
    using PetStore.Data.Models.Common;

    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Clients = new HashSet<Client>();
        }

        [Required]
        [MaxLength(AddressValidationConstants.TextMaxLength)]
        public string AddressText { get; set; }

        [Required]
        [MaxLength(AddressValidationConstants.TownNameMaxLength)]
        public string TownName { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
