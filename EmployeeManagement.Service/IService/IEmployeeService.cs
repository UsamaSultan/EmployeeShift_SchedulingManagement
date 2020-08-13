using EmployeeManagement.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.IService
{
	public interface IEmployeeService : IService<EmployeeViewModel>
	{
		Task<EmployeeViewModel> GetByEmail(string email);
	}
}
