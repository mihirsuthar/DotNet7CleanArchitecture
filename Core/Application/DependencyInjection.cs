using Application.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAppSettingsRepository, AppSettingsRepository>();

            return services;
        }
    }
}
