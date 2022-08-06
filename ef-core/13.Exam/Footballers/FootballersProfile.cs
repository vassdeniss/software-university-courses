using System.Linq;

using AutoMapper;

using Footballers.Data.Models;
using Footballers.DataProcessor.ExportDto;

namespace Footballers
{
    public class FootballersProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
        public FootballersProfile()
        {
            CreateMap<Footballer, GetFootballerDto>();

            CreateMap<Coach, ExportCoachWithFootballerDto>()
                .ForMember(d => d.Footballers,
                    mo => mo.MapFrom(
                        s => s.Footballers.OrderBy(f => f.Name)));
        }
    }
}
