using AutoMapper;

using Library.Models;
using Library.Services.Models;

namespace Library.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<ServiceCategoryViewModel, CategoryViewModel>();
            this.CreateMap<ServiceBookViewModel, BookViewModel>();
        }
    }
}
