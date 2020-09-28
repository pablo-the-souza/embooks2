using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        public OrdersController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await _repo.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            return await _repo.GetOrderByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order Order)
        {
            await _repo.PostOrder(Order);
            return CreatedAtAction("GetOrder", new { id = Order.Id }, Order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(Guid id)
        {
            var Order = await _repo.DeleteOrder(id);
            if (Order == null)
            {
                return NotFound();
            }
            return Order;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Order Order)
        {
            if (id != Order.Id)
            {
                return BadRequest();
            }
            await _repo.PutOrder(Order);
            return NoContent();
        }
    }
}
