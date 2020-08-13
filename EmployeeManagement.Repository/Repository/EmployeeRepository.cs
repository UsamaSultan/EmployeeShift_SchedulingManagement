using EmployeeManagement.Data;
using EmployeeManagement.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Repository
{
	public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(AppDbContext context) : base(context) { }

		public async Task<Employee> GetByEmail(string email)
		{
			return await this._context.Employees.Where(x=>x.Email == email).FirstOrDefaultAsync();
		}

		public async override Task UpdateAsync(Employee entity)
		{
			try
			{
				var employeeLookup = this._context.Employees.Where(x => x.Id == entity.Id).FirstOrDefault();
				employeeLookup.Firstname = entity.Firstname;
				employeeLookup.Lastname = entity.Lastname;
				employeeLookup.DateUpdate = entity.DateUpdate;
				employeeLookup.Email = entity.Email;

				this._context.Employees.Attach(employeeLookup);
				this._context.Entry(employeeLookup).State = EntityState.Modified;
				await this._context.SaveChangesAsync();
			}
			catch (DbUpdateException ex)
			{
				throw new Exception(ex.InnerException.InnerException.Message);
			}
			catch (Exception ex)
			{
				if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
				{
					throw new Exception("Duplicate unique key");
				}
				else
				{
					throw new Exception("OTHER ERROR " + ex.Message);
				}
			}
		}
	}
}
