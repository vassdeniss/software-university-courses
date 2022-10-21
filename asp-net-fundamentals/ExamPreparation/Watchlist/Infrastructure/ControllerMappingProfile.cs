using AutoMapper;

using Watchlist.Models;
using Watchlist.Services.Models;

namespace Eventures.WebApp.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            this.CreateMap<ServiceGenreViewModel, GenreViewModel>();
            this.CreateMap<ServiceMovieViewModel, MovieViewModel>();
        }
    }
}
