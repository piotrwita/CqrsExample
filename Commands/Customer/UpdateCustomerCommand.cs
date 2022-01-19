using MediatR;
using OrderProcessor.Dtos;
using System;

namespace OrderProcessor.Commands.Customer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }

        public UpdateCustomerCommand(Guid customerId, string name)
        {
            CustomerId = customerId;
            Name = name;
        }
    }
}
