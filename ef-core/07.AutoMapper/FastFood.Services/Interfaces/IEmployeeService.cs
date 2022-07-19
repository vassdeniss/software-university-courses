using FastFood.Services.Models.Employees;

namespace FastFood.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task Add(CreateEmployeeDto employeeDto);

        Task<ICollection<ListEmployeeDto>> GetAll();
    }
}
