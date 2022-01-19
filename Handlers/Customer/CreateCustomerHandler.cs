using MediatR;
using Microsoft.Extensions.Logging;
using OrderProcessor.Commands.Customer;
using OrderProcessor.Dtos;
using OrderProcessor.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers.Customer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<CreateCustomerCommand> _logger;

        public CreateCustomerHandler(ICustomersRepository customersRepository, ILogger<CreateCustomerCommand> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }


        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var order = await _customersRepository.CreateCustomerAsync(request.Name);
            _logger.LogInformation($"Created customer: {request.Name}");
            return order;
        }
    }
}
