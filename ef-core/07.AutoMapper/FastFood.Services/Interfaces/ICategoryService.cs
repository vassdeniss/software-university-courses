using FastFood.Services.Models.Categories;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Add(CreateCategoryDto categoryDto);

        Task<ICollection<ListCategoryDto>> GetAll();
    }
}
