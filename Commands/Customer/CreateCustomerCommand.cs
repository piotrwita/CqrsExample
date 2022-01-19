using MediatR;
using OrderProcessor.Dtos;

namespace OrderProcessor.Commands.Customer
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        public string Name { get; set; }

        public CreateCustomerCommand(string name)
        {
            Name = name;
        }
    }
}
