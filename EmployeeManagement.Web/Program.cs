using EmployeeManagement.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace EmployeeManagement.Web
{
    public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().SeedData().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
