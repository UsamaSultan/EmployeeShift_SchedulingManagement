using EmployeeManagement.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data
{
    public class Work : Entity
	{
		public Guid EmployeeId { get; set; }
		public Guid ShiftId { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee Employee { get; set; }

		[ForeignKey("ShiftId")]
		public virtual Shift Shift { get; set;}
	}
}
