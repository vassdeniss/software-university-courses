// ReSharper disable RedundantNameQualifier
namespace PetStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using PetStore.Data.Common.Models;
    using PetStore.Data.Models.Common;

    public class Service : BaseDeletableModel<string>
    {
        public Service()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Stores = new HashSet<Store>();
            this.Orders = new HashSet<Order>();
        }

        [Required]
        [MaxLength(ServiceValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ServiceValidationConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
