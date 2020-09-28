using System;

namespace Core.Entities
{
    public class Order
    {
        public Guid Id { get; set;}
        public DateTimeOffset Date { get; set; } 
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}