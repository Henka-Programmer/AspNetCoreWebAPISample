using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Configurations.Interfaces;

namespace AspNetCoreWebAPISample.WebAPI.Configurations
{
    public class RolesConfiguration : IConfigurer
    {
        public void Configure(IConfiguration configuration, IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roleNames = new[]
            {
                "Admin",
                "Manager",
                "Technical",
            };

            foreach (var roleName in roleNames)
            {
                var identityRole = rolesManager.FindByNameAsync(roleName).Result;
                if (identityRole == null)
                {
                    rolesManager.CreateAsync(new IdentityRole(roleName)).Wait();
                }
            }
        }
    }
}
