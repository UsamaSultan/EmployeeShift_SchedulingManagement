using EmployeeManagement.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Data
{
    public class Employee : Entity
	{
		[Required]
		public string Firstname { get; set; }
		public string Lastname { get; set; }

		[Required]
		public string Email { get; set; }
	}
}
