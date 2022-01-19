using MediatR;
using Microsoft.Extensions.Logging;
using OrderProcessor.Commands.Customer;
using OrderProcessor.Dtos;
using OrderProcessor.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers.Customer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<UpdateCustomerCommand> _logger;

        public UpdateCustomerHandler(ICustomersRepository customersRepository, ILogger<UpdateCustomerCommand> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }


        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customersRepository.UpdateCustomerAsync(request.CustomerId, request.Name);
            _logger.LogInformation($"Updated customer: {request.Name}");
            return Unit.Value;
        }
    }
}
