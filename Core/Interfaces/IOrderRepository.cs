using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid Id);
        Task<Order> PostOrder(Order Order);
        Task<Order> DeleteOrder(Guid id);
        Task<Order> PutOrder(Order Order);
    }
}