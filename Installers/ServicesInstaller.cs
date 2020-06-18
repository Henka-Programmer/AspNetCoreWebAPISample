using AspNetCoreWebAPISample.WebAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreWebAPISample.WebAPI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<ICustomersService, CustomersService>();
        }
    }
}