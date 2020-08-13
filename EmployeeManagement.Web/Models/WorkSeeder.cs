using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
	public class WorkSeeder
	{
        private readonly AppDbContext _context;
        public WorkSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            var count = _context.Works.Count();
            if (count == 0)
            {
                _context.Works.Add(entity: new Data.Work() { EmployeeId = Common.EmployeeIds[2], ShiftId = Common.ShiftIds[0], DateCreated = DateTime.Now, DateUpdate = DateTime.Now });
                _context.Works.Add(entity: new Data.Work() { EmployeeId = Common.EmployeeIds[0], ShiftId = Common.ShiftIds[1], DateCreated = DateTime.Now, DateUpdate = DateTime.Now });
                _context.Works.Add(entity: new Data.Work() { EmployeeId = Common.EmployeeIds[1], ShiftId = Common.ShiftIds[1], DateCreated = DateTime.Now, DateUpdate = DateTime.Now });

                _context.SaveChanges();
            }
        }
    }
}
