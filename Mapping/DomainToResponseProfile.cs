using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Responses;
using AspNetCoreWebAPISample.WebAPI.Domain;

namespace AspNetCoreWebAPISample.WebAPI.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
