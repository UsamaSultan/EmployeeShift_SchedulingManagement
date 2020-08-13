using EmployeeManagement.Data;
using EmployeeManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
	public class EmployeeSeeder
	{
        private readonly AppDbContext _context;
        public EmployeeSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            var count = _context.Employees.Count();
            if (count == 0)
            {
                Common.EmployeeIds.Add(Guid.NewGuid());
                Common.EmployeeIds.Add(Guid.NewGuid());
                Common.EmployeeIds.Add(Guid.NewGuid());

                _context.Employees.Add(entity: new Data.Employee() { Id = Common.EmployeeIds[0], Firstname = "John", Lastname = "Smith", DateCreated = DateTime.Now, DateUpdate = DateTime.Now, Email = "johnsmith@gmail.com" });
                _context.Employees.Add(entity: new Data.Employee() { Id = Common.EmployeeIds[1], Firstname = "David", Lastname = "Jones", DateCreated = DateTime.Now, DateUpdate = DateTime.Now, Email = "davidjones@gmail.com" });
                _context.Employees.Add(entity: new Data.Employee() { Id = Common.EmployeeIds[2], Firstname = "Michael", Lastname = "Johnson", DateCreated = DateTime.Now, DateUpdate = DateTime.Now, Email = "michaeljohnson@gmail.com" });

                _context.SaveChanges();
            }               
        }
    }
}
