using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using AspNetCoreWebAPISample.WebAPI.Data;

namespace AspNetCoreWebAPISample.WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>() 
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }

    public class AuthorizationInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddAuthorization();
            /*
             options =>
            {
                options.AddPolicy("Admin", p =>
                {
                    p.RequireAuthenticatedUser();
                    p.RequireClaim(claimType: ClaimTypes.Role, "Admin");
                });

                options.AddPolicy("Technical", p =>
                {
                    p.RequireAuthenticatedUser();
                    p.RequireClaim(claimType: ClaimTypes.Role, "Technical");
                });

                options.AddPolicy("Manager", p =>
                {
                    p.RequireAuthenticatedUser();
                    p.RequireClaim(claimType: ClaimTypes.Role, "Manager");
                });
            }
             */
        }
    }
}
