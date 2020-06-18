using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPISample.WebAPI.Configurations.Interfaces
{
    public interface IConfigurer
    {
        void Configure(IConfiguration configuration, IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider);
    }

}
