using System;

namespace EmployeeManagement.ViewModel
{
	public abstract class ViewModel
	{
		public Guid Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}
