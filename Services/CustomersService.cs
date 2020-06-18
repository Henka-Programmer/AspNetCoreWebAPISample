using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPISample.WebAPI.Data;
using AspNetCoreWebAPISample.WebAPI.Domain;

namespace AspNetCoreWebAPISample.WebAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ApplicationDbContext dbContext;
        public CustomersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await dbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<bool> UpdateCustomerAsync(Customer customerToUpdate)
        {
            dbContext.Customers.Update(customerToUpdate);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            var customer = await GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return false;
            }
            dbContext.Customers.Remove(customer);
            return await dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
