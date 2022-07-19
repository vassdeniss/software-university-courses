using FastFood.Services.Models.Orders;

namespace FastFood.Services.Interfaces
{
    public interface IOrderService
    {
        Task Add(CreateOrderDto orderDto);

        Task<ICollection<ListOrdersDto>> GetAll();
    }
}
