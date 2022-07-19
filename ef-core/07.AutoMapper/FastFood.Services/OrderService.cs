using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Orders;

using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class OrderService : IOrderService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrderService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Add(CreateOrderDto orderDto)
        {
            Order order = this.mapper.Map<Order>(orderDto);

            this.context.Orders.Add(order);

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ListOrdersDto>> GetAll()
        {
            ICollection<ListOrdersDto> orders = await this.context.Orders
                .ProjectTo<ListOrdersDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return orders;
        }
    }
}
