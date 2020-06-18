using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using AspNetCoreWebAPISample.WebAPI.Configurations.Interfaces;

namespace AspNetCoreWebAPISample.WebAPI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureAppFromAssembly(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var configurers = typeof(Startup).Assembly.ExportedTypes
               .Where(x => typeof(IConfigurer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
               .Select(t => Activator.CreateInstance(t))
               .Cast<IConfigurer>()
               .ToList();
            foreach (var cfg in configurers)
            {
                cfg.Configure(configuration, app, env, serviceProvider);
            }
        }
    }
}
