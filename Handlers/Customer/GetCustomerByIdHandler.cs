using MediatR;
using OrderProcessor.Dtos;
using OrderProcessor.Queries.Customer;
using OrderProcessor.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers.Customer
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomersRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerAsync(request.CustomerId);
            return customer == null ? null : customer
;
        }
    }
}
