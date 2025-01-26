using Company.Core.Entites;
using Company.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.APls.Controllers
{

    public class OrderController : ApiBaseController
    {


        private readonly IGenericRepository<Order> _orderRepository;

        public OrderController(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] Order order)
        {
            await _orderRepository.AddAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _orderRepository.Update(order);
            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _orderRepository.Delete(order);
            return NoContent();
        }
    }
}





