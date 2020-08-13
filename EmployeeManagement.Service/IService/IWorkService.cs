
using EmployeeManagement.ViewModel;
using EmployeeManagement.ViewModel.Work;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.IService
{
	public interface IWorkService : IService<WorkViewModel>
	{
		Task<WorkViewModel> GetByEmployeeIdAndShiftIdAndDate(Guid employeeId, Guid shiftId, DateTime Date);
		Task<WorkViewModel> GetByEmployeeIdAndDate(Guid employeeId, DateTime Date);
	}
}
