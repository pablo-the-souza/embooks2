using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> PostOrder(Order Order)
        {
            _context.Set<Order>().Add(Order);
            await _context.SaveChangesAsync();
            return Order;
        }

        public async Task<Order> DeleteOrder(Guid id)
        {
            var entity = await _context.Set<Order>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<Order>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Order> PutOrder(Order Order)
        {
            _context.Entry(Order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Order;
        }
    }
}
