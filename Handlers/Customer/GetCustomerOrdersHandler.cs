using MediatR;
using OrderProcessor.Dtos;
using OrderProcessor.Queries.Customer;
using OrderProcessor.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderProcessor.Handlers.Customer
{
    public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrdersQuery, CustomerOrdersDto>
    {
        private readonly IOrdersRepository _ordersRepository;
        public GetCustomerOrdersHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<CustomerOrdersDto> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepository.GetOrdersAsync();
            var custmerOrders = new CustomerOrdersDto
            {
                CustomerId = request.CustomerId,
                Orders = orders.Where(x => x.Customer.Id == request.CustomerId).ToList()
            };
            return custmerOrders;
        }
    }
}
