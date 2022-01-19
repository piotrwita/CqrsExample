using MediatR;
using OrderProcessor.Dtos;
using OrderProcessor.Queries.Customer;
using OrderProcessor.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers.Customer
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly ICustomersRepository _customersRepository;
        public GetAllCustomersHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customersRepository.GetCustomersAsync();
            return customers;
        }
    }
}
