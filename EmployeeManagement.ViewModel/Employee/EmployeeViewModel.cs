using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.ViewModel.Employee
{
	public class EmployeeViewModel : ViewModel
	{
		[Required]
		public string Firstname { get; set; }
		public string Lastname { get; set; }

		[Required]
		public string Email { get; set; }
	}
}
