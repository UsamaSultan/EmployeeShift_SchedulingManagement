using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.IRepository
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
		Task<Employee> GetByEmail(string email);
	}
}
