using System.Collections.Generic;

namespace AspNetCoreWebAPISample.WebAPI.Domain
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorMessage { get; set; }
        public string RefreshToken { get; internal set; }
    }

}
