using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUni.Models
{
    public partial class Employee
    {
        public Employee()
        {
            this.Departments = new HashSet<Department>();
            this.EmployeesProjects = new HashSet<EmployeeProject>();
            this.InverseManager = new HashSet<Employee>();
        }

        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [Column("DepartmentID")]
        public int DepartmentId { get; set; }

        [Column("ManagerID")]
        public int? ManagerId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime HireDate { get; set; }

        [Column(TypeName = "decimal(15, 4)")]
        public decimal Salary { get; set; }

        [Column("AddressID")]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Employees")]
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Employee.InverseManager))]
        public virtual Employee Manager { get; set; }

        [InverseProperty("Manager")]
        public virtual ICollection<Department> Departments { get; set; }

        [InverseProperty(nameof(EmployeeProject.Employee))]
        public virtual ICollection<EmployeeProject> EmployeesProjects { get; set; }

        [InverseProperty(nameof(Employee.Manager))]
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
