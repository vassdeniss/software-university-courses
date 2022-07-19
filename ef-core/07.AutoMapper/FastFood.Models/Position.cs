using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Position
	{
		public int Id { get; set; }

		[Required]
        public string Name { get; set; }

		public ICollection<Employee> Employees { get; set; }
	}
}
