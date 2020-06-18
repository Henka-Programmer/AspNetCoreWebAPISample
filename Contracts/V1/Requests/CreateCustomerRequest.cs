using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebAPISample.WebAPI.Contracts.V1.Requests
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }


}
