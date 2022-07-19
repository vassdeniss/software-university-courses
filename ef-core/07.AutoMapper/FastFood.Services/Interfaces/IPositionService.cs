using FastFood.Services.Models.Positions;

namespace FastFood.Services.Interfaces
{
    public interface IPositionService
    {
        Task Add(CreatePositionDto positionDto);

        Task<ICollection<ListPositionDto>> GetAll();
    }
}
