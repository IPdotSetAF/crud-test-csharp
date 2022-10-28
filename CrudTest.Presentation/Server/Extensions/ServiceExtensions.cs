using CrudTest.Core.Domain.RepositoryInterfaces;
using CrudTest.Core.Services;
using CrudTest.Core.Services.Abstractions;
using CrudTest.Infrastructure.Presistance;
using CrudTest.Infrastructure.Presistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudTest.Presentation.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                string ConnectionString = configuration.GetConnectionString("Crud_Test_DB");
                options.UseSqlServer(ConnectionString);
            });
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void DisableDefaultModelStateValidation(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
