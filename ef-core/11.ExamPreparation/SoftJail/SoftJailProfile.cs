using System.Globalization;
using System.Linq;
using AutoMapper;

using SoftJail.Data.Models;
using SoftJail.DataProcessor.ExportDto;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail
{
    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            CreateMap<ImportDepartmentDto, Department>();

            CreateMap<ImportCellDto, Cell>();

            CreateMap<ImportMailDto, Mail>();

            CreateMap<ImportOfficerDto, Officer>();

            CreateMap<Mail, ExportMailDto>()
                .ForMember(d => d.Description,
                    mo => mo.MapFrom(
                        s => string.Join("", s.Description.Reverse())));

            CreateMap<Prisoner, ExportPrisonerInboxDto>()
                .ForMember(d => d.IncarcerationDate,
                    mo => mo.MapFrom(
                        s => s.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
        }
    }
}
