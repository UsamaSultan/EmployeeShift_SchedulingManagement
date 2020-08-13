using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement.Web.Models
{
	public static class WebHostExtensions
	{
        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<AppDbContext>();

                // now we have the DbContext. Run migrations
                context.Database.Migrate();

                new EmployeeSeeder(context).SeedData();

                new ShiftSeeder(context).SeedData();

                new WorkSeeder(context).SeedData();
            }

            return host;
        }
    }
}
