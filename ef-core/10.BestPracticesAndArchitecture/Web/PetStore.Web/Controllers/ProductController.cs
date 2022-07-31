namespace PetStore.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PetStore.Data.Models;
    using PetStore.Services.Data;
    using Services.Mapping;
    using ViewModels.Product;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create()
        {
            ICollection<ListCategoriesOnProductCreateViewModel> allCategories =
                this.categoryService.All().To<ListCategoriesOnProductCreateViewModel>().ToArray();

            return this.View(allCategories);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Create(CreateProductInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Product");
            }

            if (!this.categoryService.ExistsById(model.CategoryId))
            {
                return this.RedirectToAction("Create", "Product");
            }

            Product product = AutoMapperConfig.MapperInstance.Map<Product>(model);
            await this.productService.AddProduct(product);

            return this.RedirectToAction("All", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Product product = await this.productService.GetById(id);
            if (product == null)
            {
                this.RedirectToAction("Error", "Home");
            }

            DetailsProductViewModel viewModel = 
                AutoMapperConfig.MapperInstance.Map<DetailsProductViewModel>(product);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult All(string search)
        {
            IQueryable allProducts = this.productService.GetAllByName(search);
            ICollection<string> categories = this.productService.GetAllProductsCategories();

            AllProductsViewModel viewModel = new AllProductsViewModel()
            {
                AllProducts = allProducts.To<ListAllProductViewModel>().ToArray(),
                Categories = categories,
                SearchQuery = search
            };

            return this.View(viewModel);
        }
    }
}
