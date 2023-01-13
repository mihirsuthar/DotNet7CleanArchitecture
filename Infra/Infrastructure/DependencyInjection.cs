using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationDBContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"), b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)),
            //    ServiceLifetime.Transient);

            //services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
            return services;
        }
    }
}
