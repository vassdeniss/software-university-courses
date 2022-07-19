using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Positions;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Positions;

using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class PositionsController : Controller
    {
        private readonly IPositionService service;
        private readonly IMapper mapper;

        public PositionsController(IPositionService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePositionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Create", "Positions");
            }

            CreatePositionDto positionDto = this.mapper.Map<CreatePositionDto>(model);
            await this.service.Add(positionDto);

            return RedirectToAction("All", "Positions");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListPositionDto> positionDtos = await this.service.GetAll();

            IList<PositionsAllViewModel> allPositions = positionDtos
                .Select(dto => this.mapper.Map<PositionsAllViewModel>(dto))
                .ToList();

            return View(allPositions);
        }
    }
}
