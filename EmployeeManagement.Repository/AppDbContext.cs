using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Repository
{
	public class AppDbContext : DbContext
	{		
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
				
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Shift> Shifts { get; set; }
		public DbSet<Work> Works { get; set; }
	}
}
