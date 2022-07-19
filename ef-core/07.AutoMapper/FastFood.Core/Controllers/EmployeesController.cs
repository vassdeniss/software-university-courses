using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FastFood.Services.Interfaces;
using FastFood.Services.Models.Employees;
using FastFood.Services.Models.Positions;
using FastFood.Web.ViewModels.Employees;

using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public EmployeesController(IPositionService positionService, IEmployeeService employeeService, IMapper mapper)
        {
            this.positionService = positionService;
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Register()
        {
            ICollection<ListPositionDto> positions = await this.positionService
                .GetAll();

            IList<RegisterEmployeeViewModel> positionsViews = positions
                .Select(dto => this.mapper.Map<RegisterEmployeeViewModel>(dto))
                .ToList();

            return View(positionsViews);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Register", "Employees");
            }

            CreateEmployeeDto employeeDto = this.mapper.Map<CreateEmployeeDto>(model);
            await this.employeeService.Add(employeeDto);

            return RedirectToAction("All", "Employees");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListEmployeeDto> employeeDtos = await this.employeeService.GetAll();

            IList<EmployeesAllViewModel> allEmployees = employeeDtos
                .Select(dto => this.mapper.Map<EmployeesAllViewModel>(dto))
                .ToList();

            return View(allEmployees);
        }
    }
}
