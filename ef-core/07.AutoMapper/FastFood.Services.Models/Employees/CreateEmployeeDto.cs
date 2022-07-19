namespace FastFood.Services.Models.Employees
{
    public class CreateEmployeeDto
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public int PositionId { get; set; }

        public string? PositionName { get; set; }

        public string? Address { get; set; }
    }
}
