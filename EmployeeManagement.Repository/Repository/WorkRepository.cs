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
	public class WorkRepository : Repository<Work>, IWorkRepository
	{
		public WorkRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Work> GetByEmployeeIdAndDate(Guid employeeId, DateTime Date)
		{
			return await this._context.Works.Where(x => x.EmployeeId == employeeId && x.DateCreated.Date == Date.Date).FirstOrDefaultAsync();
		}

		public async Task<Work> GetByEmployeeIdAndShiftIdAndDate(Guid employeeId, Guid shiftId, DateTime Date)
		{
			return await this._context.Works.Where(x => x.EmployeeId == employeeId && x.ShiftId == shiftId && x.DateCreated.Date == Date.Date).FirstOrDefaultAsync();
		}

		public async override Task UpdateAsync(Work entity)
		{
			try
			{
				var workLookup = this._context.Works.Where(x=> x.Id == entity.Id).FirstOrDefault();
				workLookup.EmployeeId = entity.EmployeeId;
				workLookup.ShiftId = entity.ShiftId;
				workLookup.DateUpdate = entity.DateUpdate;

				this._context.Works.Attach(workLookup);
				this._context.Entry(workLookup).State = EntityState.Modified;
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
