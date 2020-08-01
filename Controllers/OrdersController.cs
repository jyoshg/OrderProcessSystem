using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProcessSystem.Data;
using OrderProcessSystem.Models;

namespace OrderProcessSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDBContext _context;

        public OrdersController(OrderDBContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return await _context.Order.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var order = await _context.Order.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet("{id}")]
        [ActionName("GetItemByCategory")]
        public async Task<ActionResult<OrderCategory>> GetOrder(int id)
        {
            var orderCategory = await _context.OrderCategory.FindAsync(id);

            if (orderCategory == null)
            {
                return NotFound();
            }

            return orderCategory;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, Order order)
        {
            if (id != order.OrderId && !_context.Order.Any(e=>e.Product.CategoryID==order.Product.CategoryID && e.accountId==order.accountId))
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(PostOrderInput productInput)
        {
            string orderIdWithCategoryForAccount = GetOrderIdWithCategoryForAccount(productInput);
            var order = OrderModelBinding(orderIdWithCategoryForAccount, productInput);
            _context.Order.Add(order);           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderExists(order.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(string id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(string Id)
        {
            return _context.Order.Any(e => e.OrderId==Id);
        }

        public string GetOrderIdWithCategoryForAccount(PostOrderInput input)
        {
            return _context.Order.Where(e => e.accountId == input.accountId && e.Product.CategoryID == input.product.CategoryID).Select(e=>e.OrderId).FirstOrDefault();
        }

        public Order OrderModelBinding(string orderIdExists,PostOrderInput input)
        {
            Order order = new Order();
            if (!String.IsNullOrEmpty(orderIdExists))
            {
                order.OrderId = orderIdExists;
            }
            else
            {
                order.OrderId = Guid.NewGuid().ToString();
            }
            order.Product = input.product;
            order.Quantity = input.quantity;
            order.accountName = input.accountName;
            order.accountId = input.accountId;
            return order;
        }
    }
}
