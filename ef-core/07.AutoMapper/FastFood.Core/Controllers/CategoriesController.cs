using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Web.ViewModels.Categories;

using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService service;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Create", "Categories");
            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);
            await this.service.Add(categoryDto);

            return RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListCategoryDto> categoryDtos = await this.service.GetAll();

            IList<CategoryAllViewModel> allCategories = categoryDtos
                .Select(dto => this.mapper.Map<CategoryAllViewModel>(dto))
                .ToList();

            return View(allCategories);
        }
    }
}
