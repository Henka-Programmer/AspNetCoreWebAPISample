using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Configurations.Interfaces;
using AspNetCoreWebAPISample.WebAPI.Options;

namespace AspNetCoreWebAPISample.WebAPI.Configurations
{
    public class SwaggerConfiguration : IConfigurer
    {
        public void Configure(IConfiguration configuration, IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var swaggerOptions = new SwaggerOptions();

            configuration.GetSection(nameof(swaggerOptions)).Bind(swaggerOptions);
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(opt =>
            {
                opt.RouteTemplate = swaggerOptions.JsonRoute;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);

            });
        }
    }
}
