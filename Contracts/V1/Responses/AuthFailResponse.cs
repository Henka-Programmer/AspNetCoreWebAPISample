using System.Collections.Generic;

namespace AspNetCoreWebAPISample.WebAPI.Contracts.V1.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
