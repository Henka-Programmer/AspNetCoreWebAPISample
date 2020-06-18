using System;

namespace AspNetCoreWebAPISample.WebAPI.Contracts.V1.Requests
{
    public class UpdateCustomerRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }

}
