using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AspNetCoreWebAPISample.WebAPI.Installers;

namespace AspNetCoreWebAPISample.WebAPI.Extensions
{
    public static class InstallerExtensions
    {
        public static void InstallServicesFromAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
               .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
               .Select(t => Activator.CreateInstance(t))
               .Cast<IInstaller>()
               .ToList();
            foreach (var installer in installers)
            {
                installer.InstallServices(configuration, services);
            }
        }


    }
}
