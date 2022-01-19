using MediatR;
using OrderProcessor.Dtos;
using System;

namespace OrderProcessor.Queries.Customer
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid CustomerId { get; set; }

        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
