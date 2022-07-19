using AutoMapper;

using FastFood.Models;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Employees;
using FastFood.Services.Models.Items;
using FastFood.Services.Models.Orders;
using FastFood.Services.Models.Positions;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Employees;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;
using FastFood.Web.ViewModels.Positions;

namespace FastFood.Web.MappingConfiguration
{
    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            // Categories
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateCategoryInputModel, CreateCategoryDto>()
                .ForMember(dest => dest.Name, mo => mo.MapFrom(source => source.CategoryName));
            CreateMap<Category, ListCategoryDto>();
            CreateMap<ListCategoryDto, CategoryAllViewModel>();

            // Positions
            CreateMap<CreatePositionDto, Position>();
            CreateMap<CreatePositionInputModel, CreatePositionDto>()
                .ForMember(dest => dest.Name, mo => mo.MapFrom(source => source.PositionName));
            CreateMap<Position, ListPositionDto>();
            CreateMap<ListPositionDto, PositionsAllViewModel>();

            // Employees
            CreateMap<ListPositionDto, RegisterEmployeeViewModel>()
                .ForMember(dest => dest.PositionId, mo => mo.MapFrom(source => source.Id));
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<RegisterEmployeeInputModel, CreateEmployeeDto>();
            CreateMap<Employee, ListEmployeeDto>();
            CreateMap<ListEmployeeDto, EmployeesAllViewModel>()
                .ForMember(dest => dest.Position, mo => mo.MapFrom(source => source.PositionName));

            // Items
            CreateMap<ListCategoryDto, CreateItemViewModel>()
                .ForMember(dest => dest.CategoryId, mo => mo.MapFrom(source => source.Id));
            CreateMap<CreateItemDto, Item>();
            CreateMap<CreateItemInputModel, CreateItemDto>();
            CreateMap<Item, ListItemDto>();
            CreateMap<ListItemDto, ItemsAllViewModels>()
                .ForMember(dest => dest.Category, mo => mo.MapFrom(source => source.CategoryName));

            // Orders
            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateOrderInputModel, CreateOrderDto>();
            CreateMap<Order, ListOrdersDto>();
            CreateMap<ListOrdersDto, OrderAllViewModel>();
        }
    }
}
