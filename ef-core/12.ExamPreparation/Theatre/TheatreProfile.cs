using System.Linq;
using AutoMapper;

using Theatre.Data.Models;
using Theatre.DataProcessor.ExportDto;
using Theatre.DataProcessor.ImportDto;

namespace Theatre
{
    class TheatreProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public TheatreProfile()
        {
            CreateMap<ImportTicketDto, Ticket>();

            CreateMap<Cast, ExportActorDto>()
                .ForMember(d => d.MainCharacter,
                    mo => mo.MapFrom(
                        s => $"Plays main character in '{s.Play.Title}'."));

            CreateMap<Play, ExportPlayDto>()
                .ForMember(d => d.Duration,
                    mo => mo.MapFrom(
                        s => s.Duration.ToString("c")))
                .ForMember(d => d.Casts,
                    mo => mo.MapFrom(
                        s => s.Casts.Where(c => c.IsMainCharacter).OrderByDescending(c => c.FullName)))
                .ForMember(d => d.Rating,
                    mo => mo.MapFrom(
                        s => s.Rating == 0 ? "Premier" : s.Rating.ToString()));
        }
    }
}
