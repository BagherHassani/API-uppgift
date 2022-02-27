#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _02_API;
using _02_API.Models.Entity;
using _02_API.Models;

namespace _02_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly SqlContext _context;

        public OrderController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderEntity>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderEntity>> GetOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);

            if (orderEntity == null)
            {
                return NotFound();
            }

            return orderEntity;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderEntity(int id, OrderEntity orderEntity)
        {
            if (id != orderEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderEntityExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderUoutPutModel>> PostOrderEntity(OrderModel model)
        {
            if(!await _context.Users.AnyAsync(x => x.Id == model.UserId))
                return BadRequest();

         
            var orderEntity = new OrderEntity(model.AntalProduct, model.Created,model.Status);

            var _products = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.ProductId);

            if (_products != null)

                orderEntity.ProductId = _products.Id;

            var _user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
            if (_user != null)
                orderEntity.UserId = _user.Id;


            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();
            //var _orderEntity = await _context.Orders.Include(x => x.Users).Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == orderEntity.UserId && x.Id == orderEntity.ProductId);


            return CreatedAtAction("GetOrderEntity", new { id = orderEntity.Id }, new OrderUoutPutModel(
                orderEntity.Created, orderEntity.AntalProduct, orderEntity.Status,
                new OrderUserUotPutModel(orderEntity.Users.FirstName, orderEntity.Users.LastName, orderEntity.Users.Email),
            new ProductModel(orderEntity.Products.ArticalNumber,
                    orderEntity.Products.Description, orderEntity.Products.PrdoductType,
                    orderEntity.Products.Price, orderEntity.Products.PrdoductType, orderEntity.Products.Categori)));









            //        new ProductModel(_orderEntity.Products.ArticalNumber,
            //        _orderEntity.Products.Description, _orderEntity.Products.PrdoductType,
            //        _orderEntity.Products.PrdoductName, _orderEntity.Products.Categori, _orderEntity.Products.Price),
            //        new UserUtPutModel(_orderEntity.Users.FirstName, _orderEntity.Users.LastName, _orderEntity.Users.Email)));
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderEntity(int id)
        {
            var orderEntity = await _context.Orders.FindAsync(id);
            if (orderEntity == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderEntityExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
