using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ViewModel.Work
{
	public class WorkViewModel : ViewModel
	{
		public Guid EmployeeId { get; set; }
		public Guid ShiftId { get; set; }
	}
}
