using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid Id);
        Task<Customer> PostCustomer(Customer Customer);
        Task<Customer> DeleteCustomer(Guid id);
        Task<Customer> PutCustomer(Customer Customer);
    }
}