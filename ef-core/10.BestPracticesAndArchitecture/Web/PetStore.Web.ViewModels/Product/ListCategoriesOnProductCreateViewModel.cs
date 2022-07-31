namespace PetStore.Web.ViewModels.Product
{
    using PetStore.Data.Models;
    using PetStore.Services.Mapping;

    public class ListCategoriesOnProductCreateViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
