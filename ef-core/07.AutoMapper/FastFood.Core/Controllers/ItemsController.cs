using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;
using FastFood.Web.ViewModels.Items;

using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;
        private readonly IMapper mapper;

        public ItemsController(ICategoryService categoryService, IItemService itemService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.itemService = itemService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Create()
        {
            ICollection<ListCategoryDto> categories = await this.categoryService
                .GetAll();

            IList<CreateItemViewModel> categoryViews = categories
                .Select(dto => this.mapper.Map<CreateItemViewModel>(dto))
                .ToList();

            return View(categoryViews);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Create", "Items");
            }

            CreateItemDto itemDto = this.mapper.Map<CreateItemDto>(model);
            await this.itemService.Add(itemDto);

            return RedirectToAction("All", "Items");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListItemDto> itemDtos = await this.itemService.GetAll();

            IList<ItemsAllViewModels> allItems = itemDtos
                .Select(dto => this.mapper.Map<ItemsAllViewModels>(dto))
                .ToList();

            return View(allItems);
        }
    }
}
