using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FastFood.Services.Interfaces;
using FastFood.Services.Models.Employees;
using FastFood.Services.Models.Items;
using FastFood.Services.Models.Orders;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;

using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IItemService itemService;
        private readonly IEmployeeService employeeService;
        private readonly IMapper mapper;

        public OrdersController(IOrderService orderService, IItemService itemService, IEmployeeService employeeService, IMapper mapper)
        {
            this.orderService = orderService;
            this.itemService = itemService;
            this.employeeService = employeeService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Create()
        {
            ICollection<ListItemDto> items = await this.itemService
                .GetAll();

            ICollection<ListEmployeeDto> employees = await this.employeeService
                .GetAll();

            CreateOrderViewModel itemsEmployees = new CreateOrderViewModel
            {
                Items = items.Select(x => x.Id).ToList(),
                Employees = employees.Select(x => x.Id).ToList()
            };

            return View(itemsEmployees);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Create", "Orders");
            }

            CreateOrderDto orderDto = this.mapper.Map<CreateOrderDto>(model);
            await this.orderService.Add(orderDto);

            return RedirectToAction("All", "Orders");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListOrdersDto> orderDtos = await this.orderService.GetAll();

            IList<OrderAllViewModel> allItems = orderDtos
                .Select(dto => this.mapper.Map<OrderAllViewModel>(dto))
                .ToList();

            return View(allItems);
        }
    }
}
