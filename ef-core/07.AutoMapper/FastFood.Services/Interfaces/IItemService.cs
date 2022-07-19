using FastFood.Services.Models.Items;

namespace FastFood.Services.Interfaces
{
    public interface IItemService
    {
        Task Add(CreateItemDto itemDto);

        Task<ICollection<ListItemDto>> GetAll();
    }
}
