using MediatR;
using OrderProcessor.Dtos;
using System;
using System.Collections.Generic;

namespace OrderProcessor.Queries.Customer
{
    public class GetCustomerOrdersQuery : IRequest<CustomerOrdersDto>
    {
        public Guid CustomerId { get; set; }

        public GetCustomerOrdersQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
