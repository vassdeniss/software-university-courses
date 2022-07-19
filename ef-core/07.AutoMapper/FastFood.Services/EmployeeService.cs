using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Employees;

using Microsoft.EntityFrameworkCore;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task Add(CreateEmployeeDto employeeDto)
        {
            Employee employee = this.mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ListEmployeeDto>> GetAll()
        {
            ICollection<ListEmployeeDto> employees = await this.context.Employees
                .ProjectTo<ListEmployeeDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

            return employees;
        }
    }
}
