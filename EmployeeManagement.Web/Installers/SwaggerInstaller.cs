using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace EmployeeManagement.Web.Installers
{
    public static class SwaggerInstaller
    {
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(so =>
            {
                so.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });
        }

        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(so =>
            {
                so.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Employee Management API",
                    Description = "API",
                    Contact = new OpenApiContact
                    {
                        Name = "Employee Management",
                        Email = "support@example.com",                        
                    }
                });
                so.DescribeAllParametersInCamelCase();
                so.CustomSchemaIds(x => x.FullName);
            });
        }
    }
}
