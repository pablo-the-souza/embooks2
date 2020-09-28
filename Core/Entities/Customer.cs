using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Customer
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}