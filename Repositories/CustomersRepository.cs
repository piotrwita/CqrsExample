using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessor.Dtos;

namespace OrderProcessor.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly List<CustomerDto> _customers = new List<CustomerDto>
        {
            new CustomerDto{Id = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"), Name = "Patryk S�adek"},
            new CustomerDto{Id = Guid.Parse("fc7cdfc4-f407-4955-acbe-98c666ee51a2"), Name = "Jan Kowalski"},
            new CustomerDto{Id = Guid.Parse("a46ac8f4-2ecd-43bf-a9e6-e557b9af1d6e"), Name = "Tomasz Nowak"}
        };
        
        public Task<CustomerDto> GetCustomerAsync(Guid customerId)
        {
            return Task.FromResult(_customers.SingleOrDefault(x => x.Id == customerId));
        }

        public Task<List<CustomerDto>> GetCustomersAsync()
        {
            return Task.FromResult(_customers);
        }

        public Task<CustomerDto> CreateCustomerAsync(string name)
        {
            var customer = new CustomerDto
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            _customers.Add(customer);
            return Task.FromResult(customer);
        }

        public Task UpdateCustomerAsync(Guid customerId, string name)
        {
            var customer = GetCustomerAsync(customerId);
            customer.Result.Name = name;
            return Task.CompletedTask;
        }

        public Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = GetCustomerAsync(customerId);
            _customers.Remove(customer.Result);
            return Task.CompletedTask;
        }
    }
}