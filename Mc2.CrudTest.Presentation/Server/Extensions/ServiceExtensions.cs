using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Presentation.Server.Extensions
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
    }
}
