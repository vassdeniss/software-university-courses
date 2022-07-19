using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Positions;

using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class PositionService : IPositionService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public PositionService(FastFoodContext context, IMapper mappert)
        {
            this.context = context;
            this.mapper = mappert;
        }

        public async Task Add(CreatePositionDto positionDto)
        {
            Position position = this.mapper.Map<Position>(positionDto);

            this.context.Positions.Add(position);

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ListPositionDto>> GetAll()
        {
            ICollection<ListPositionDto> positions = await this.context.Positions
                .ProjectTo<ListPositionDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return positions;
        }
    }
}
