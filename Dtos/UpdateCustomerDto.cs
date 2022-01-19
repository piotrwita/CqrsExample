using System;

namespace OrderProcessor.Dtos
{
    public class UpdateCustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}