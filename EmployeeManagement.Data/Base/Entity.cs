using System;

namespace EmployeeManagement.Data.Base
{
	public abstract class Entity
	{
		public Guid Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}
