using System;
using System.Linq;
using System.Threading.Tasks;
using OrderProcessor.Repositories;
using Microsoft.AspNetCore.Mvc;
using OrderProcessor.Dtos;
using MediatR;
using OrderProcessor.Commands.Customer;
using OrderProcessor.Queries;
using OrderProcessor.Queries.Customer;

namespace OrderProcessor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator, ICustomersRepository customersRepository, IOrdersRepository ordersRepository)
        {
            _customersRepository = customersRepository;
            _ordersRepository = ordersRepository;
            _mediator = mediator;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
        {
            var command = new GetAllCustomersQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var command = new GetCustomerByIdQuery(customerId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(Guid customerId)
        {
            var command = new GetCustomerOrdersQuery(customerId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(CreateCustomerDto newCustomer)
        {
            var command = new CreateCustomerCommand(newCustomer.Name);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetCustomer", new { customerId = result.Id }, result);
        } 

        [HttpPut("")]
        public async Task<IActionResult> UpdateAsync(UpdateCustomerDto updateCustomer)
        {
            var command = new UpdateCustomerCommand(updateCustomer.Id, updateCustomer.Name);
            var result = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteAsync(Guid customerId)
        {
            var command = new DeleteCustomerCommand(customerId);
            var result = await _mediator.Send(command);
            return NoContent();
        }
    }
}