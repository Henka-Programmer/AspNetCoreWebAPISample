using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPISample.WebAPI.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Version = "v1";
        public const string Root = "api";
        public const string Base = Root + "/" + Version;
        public static class Customers
        {
            public const string GetAll = Base + "/customers";
            public const string Create = Base + "/customers";
            public const string Update = Base + "/customers/{customerId}";
            public const string Get = Base + "/customers/{customerId}";
            public const string Delete = Base + "/customers/{customerId}";
        }
            
        public static class Identity
        {
            public const string Login = Base + "/identity/login";
            public const string Refresh = Base + "/identity/refresh";
            public const string Register = Base + "/identity/register";
        }
    }
}
