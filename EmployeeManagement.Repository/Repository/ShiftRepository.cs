using EmployeeManagement.Repository.Repository;
using EmployeeManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Data;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository.Repository
{
	public class ShiftRepository : Repository<Shift>, IShiftRepository
	{
		public ShiftRepository(AppDbContext context) : base(context)
		{
		}

		public async override Task UpdateAsync(Shift entity)
		{
			try
			{
				var shiftLookup = this._context.Shifts.Where(x => x.Id == entity.Id).FirstOrDefault();
				shiftLookup.DateUpdate = entity.DateUpdate;
				shiftLookup.From = entity.From;
				shiftLookup.To = entity.To;
				shiftLookup.Name = entity.Name;

				this._context.Shifts.Attach(shiftLookup);
				this._context.Entry(shiftLookup).State = EntityState.Modified;
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
