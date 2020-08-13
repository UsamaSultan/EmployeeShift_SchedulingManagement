using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ViewModel.Shift
{
	public class ShiftViewModel : ViewModel
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public string From { get; set; }
		public string To { get; set; }

	}
}
