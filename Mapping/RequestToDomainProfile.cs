using AutoMapper;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Requests;
using AspNetCoreWebAPISample.WebAPI.Domain;

namespace AspNetCoreWebAPISample.WebAPI.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<CreateCustomerRequest, Customer>();
        }
    }
}
