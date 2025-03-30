using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using ECommerceApplication.Application.Features.OrderFeature.Command.UpdateCommand;
using ECommerceApplication.Application.Features.OrderFeature.Query.GetAllOrdersQuery;
using ECommerceApplication.Application.Features.OrderFeature.Query.GetOrderByIdQuery;
using ECommerceApplication.Application.Features.OrderFeature.Command.AddCommand;
using ECommerceApplication.Application.Features.OrderFeature.Command.DeleteCommand;

namespace ECommerceApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Orders>> AddOrder([FromBody] AddOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        // PUT: api/order/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id,  UpdateOrderCommand command)
        {
            if (id != command.order.OrderId)
            {
                return BadRequest("Order ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}