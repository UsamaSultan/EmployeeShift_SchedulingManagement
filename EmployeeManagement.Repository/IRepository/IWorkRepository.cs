using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.IRepository
{
	public interface IWorkRepository : IRepository<Work>
	{
		Task<Work> GetByEmployeeIdAndShiftIdAndDate(Guid employeeId, Guid shiftId, DateTime Date);
		Task<Work> GetByEmployeeIdAndDate(Guid employeeId, DateTime Date);
	}
}
