// ReSharper disable RedundantNameQualifier
namespace PetStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using PetStore.Data.Common.Models;
    using PetStore.Data.Models.Common;

    public class Store : BaseDeletableModel<string>
    {
        public Store()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Pets = new HashSet<Pet>();
            this.Products = new HashSet<Product>();
            this.Services = new HashSet<Service>();
        }

        [Required]
        [MaxLength(StoreValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(StoreValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
