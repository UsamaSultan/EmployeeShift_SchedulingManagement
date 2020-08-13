using EmployeeManagement.Data.Base;
using System;

namespace EmployeeManagement.Data
{
    public class Shift : Entity
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public string From { get; set; }
		public string To { get; set; }
	}
}
