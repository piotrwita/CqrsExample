using MediatR;
using OrderProcessor.Dtos;
using System.Collections.Generic;

namespace OrderProcessor.Queries.Customer
{
    public class GetAllCustomersQuery : IRequest<List<CustomerDto>>
    {
    }
}
