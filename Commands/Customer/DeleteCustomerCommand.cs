using MediatR;
using OrderProcessor.Dtos;
using System;

namespace OrderProcessor.Commands.Customer
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public Guid CustomerId { get; set; }

        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
