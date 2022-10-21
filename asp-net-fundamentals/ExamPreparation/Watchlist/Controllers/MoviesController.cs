using System.Security.Claims;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Watchlist.Models;
using Watchlist.Services.Contracts;
using Watchlist.Services.Models;

namespace Watchlist.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IMovieService movieService;

        public MoviesController(IMapper mapper, IMovieService movieService)
        {
            this.mapper = mapper;
            this.movieService = movieService;
        }

        public async Task<IActionResult> All()
        {
            ICollection<ServiceMovieViewModel> models = await this.movieService.GetMoviesAsync();
            ICollection<MovieViewModel> model = this.mapper.Map<ICollection<MovieViewModel>>(models);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddMovieViewModel model = new AddMovieViewModel();

            model.Genres = this.mapper.Map<ICollection<GenreViewModel>>(
                await this.movieService.GetGenresAsync());

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.movieService.AddMovieAsync(model.Title,
                model.Director,
                model.ImageUrl,
                model.Rating,
                model.GenreId);

            return RedirectToAction("All", "Movies");
        }

        [HttpGet]
        public async Task<IActionResult> Watched()
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            ICollection<MovieViewModel> model = this.mapper.Map<ICollection<MovieViewModel>>(
                await this.movieService.GetUserMoviesAsync(userId));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int movieId)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            await this.movieService.AddMovieToCollectionAsync(movieId, userId);

            return RedirectToAction("All", "Movies");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int movieId)
        {
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            await this.movieService.RemoveMovieFromCollectionAsync(movieId, userId);

            return RedirectToAction("Watched", "Movies");
        }
    }
}
