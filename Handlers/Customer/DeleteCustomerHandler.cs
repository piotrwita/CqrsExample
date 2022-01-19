using MediatR;
using Microsoft.Extensions.Logging;
using OrderProcessor.Commands.Customer;
using OrderProcessor.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers.Customer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ILogger<DeleteCustomerCommand> _logger;

        public DeleteCustomerHandler(ICustomersRepository customersRepository, ILogger<DeleteCustomerCommand> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }


        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customersRepository.DeleteCustomerAsync(request.CustomerId);
            _logger.LogInformation($"Deleted customer: {request.CustomerId}");
            return Unit.Value;
        }
    }
}
