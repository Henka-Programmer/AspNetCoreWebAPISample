using System;

namespace AspNetCoreWebAPISample.WebAPI.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
