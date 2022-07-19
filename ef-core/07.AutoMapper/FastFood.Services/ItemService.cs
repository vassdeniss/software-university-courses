using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Items;

using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class ItemService : IItemService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Add(CreateItemDto itemDto)
        {
            Item item = this.mapper.Map<Item>(itemDto);

            this.context.Items.Add(item);

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ListItemDto>> GetAll()
        {
            ICollection<ListItemDto> items = await this.context.Items
                .ProjectTo<ListItemDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return items;
        }
    }
}
