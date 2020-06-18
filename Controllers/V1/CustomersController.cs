using AspNetCoreWebAPISample.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1;
using AspNetCoreWebAPISample.WebAPI.Domain;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Requests;
using AspNetCoreWebAPISample.WebAPI.Contracts.V1.Responses;
using AutoMapper;
using System.Collections.Generic;

namespace AspNetCoreWebAPISample.WebAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : Controller
    {
        private readonly ICustomersService customersService;
        private readonly IMapper _mapper;
        public CustomersController(ICustomersService customersService, IMapper mapper)
        {
            this.customersService = customersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Customers.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var customers = await customersService.GetCustomersAsync();

            return base.Ok(_mapper.Map<List<CustomerResponse>>(customers));
        }

        /// <summary>
        /// Gets a specific Customer
        /// </summary>
        /// <param name="customerId">The target Customer id</param>
        /// <returns>the Customer if exists otherwise a not found error message</returns>
        [HttpGet(ApiRoutes.Customers.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid customerId)
        {
            var customer = await customersService.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CustomerResponse>(customer));
        }

        [HttpDelete(ApiRoutes.Customers.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid customerId)
        {
            var deleted = await customersService.DeleteCustomerAsync(customerId);
            if (deleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut(ApiRoutes.Customers.Update)]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = _mapper.Map<Customer>(updateCustomerRequest);

            if (await customersService.UpdateCustomerAsync(customer))
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost(ApiRoutes.Customers.Create)]
        public async Task<IActionResult> Create([FromBody]CreateCustomerRequest customerRequest)
        {
            var customer = _mapper.Map<Customer>(customerRequest);

            customer = await customersService.CreateCustomerAsync(customer);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = $"{baseUrl}/{ApiRoutes.Customers.Get.Replace("{customerId}", customer.Id.ToString())}";
            return Created(locationUrl, _mapper.Map<CustomerResponse>(customer));
        }
    }
}
