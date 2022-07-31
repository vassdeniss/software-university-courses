namespace PetStore.Web.ViewModels.Product
{
    using Data.Models;
    using Services.Mapping;
    using PetStore.Data.Models;

    public class ListAllProductViewModel : IMapFrom<Product>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
