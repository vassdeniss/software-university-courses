using System.Security.Claims;

using AutoMapper;

using Library.Models;
using Library.Services.Contracts;
using Library.Services.Models;

using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : BaseController
    {
        private readonly IMapper mapper;
        private readonly IBookService bookService;

        public BooksController(IMapper mapper, IBookService bookService)
        {
            this.mapper = mapper;
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            ICollection<ServiceBookViewModel> serviceModel = await this.bookService.GetBooksAsync();
            ICollection<BookViewModel> model = this.mapper.Map<ICollection<BookViewModel>>(serviceModel);

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = new AddBookViewModel();

            model.Categories = this.mapper.Map<ICollection<CategoryViewModel>>(
                await this.bookService.GetCategoriesAsync());

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.bookService.AddBookAsync(model.Title,
                model.Author,
                model.Description,
                model.ImageUrl,
                model.Rating,
                model.CategoryId);

            return this.RedirectToAction("All", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = this.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                .Value;

            ICollection<BookViewModel> model = this.mapper.Map<ICollection<BookViewModel>>(
                await this.bookService.GetUserBooksAsync(userId));

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            string userId = this.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                .Value;

            await this.bookService.AddBookToCollectionAsync(bookId, userId);

            return this.RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            string userId = this.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                .Value;

            await this.bookService.RemoveBookFromCollectionAsync(bookId, userId);

            return this.RedirectToAction("Mine", "Books");
        }
    }
}
