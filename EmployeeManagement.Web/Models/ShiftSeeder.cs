using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class ShiftSeeder
    {
        private readonly AppDbContext _context;
        public ShiftSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            var count = _context.Shifts.Count();
            if (count == 0)
            {
                Common.ShiftIds.Add(Guid.NewGuid());
                Common.ShiftIds.Add(Guid.NewGuid());
                var Date = DateTime.Now.AddDays(7).Date;

                _context.Shifts.Add(entity: new Data.Shift() { Id = Common.ShiftIds[0], Date = Date, DateCreated = DateTime.Now, DateUpdate = DateTime.Now, From = "9:00", To = "17:00", Name = "Morning Shift" });
                _context.Shifts.Add(entity: new Data.Shift() { Id = Common.ShiftIds[1], Date = Date, DateCreated = DateTime.Now, DateUpdate = DateTime.Now, From = "18:00 ", To = "2:00", Name = "Day Shift" });
                _context.SaveChanges();
            }
        }
    }
}
