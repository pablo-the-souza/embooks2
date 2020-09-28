using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> PostCustomer(Customer Customer)
        {
            _context.Set<Customer>().Add(Customer);
            await _context.SaveChangesAsync();
            return Customer;
        }

        public async Task<Customer> DeleteCustomer(Guid id)
        {
            var entity = await _context.Set<Customer>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<Customer>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Customer> PutCustomer(Customer Customer)
        {
            _context.Entry(Customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Customer;
        }
    }
}
