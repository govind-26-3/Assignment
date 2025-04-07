using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceApplication.Domain;
using ECommerceApplication.Application.Features.OrderItemFeature.Query.GetOrderItemsQuery;
using ECommerceApplication.Application.Features.OrderItemFeature.Command.AddOrderItemCommand;
using ECommerceApplication.Application.Features.OrderItemFeature.Command.UpdateOrderItemCommand;
using ECommerceApplication.Application.Features.OrderItemFeature.Command.DeleteOrderItemCommand;
using ECommerceApplication.Application.Features.OrderItemFeature.Query.GetOrderItemByIdQuery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ECommerceApplication.Identity.Model;
namespace ECommerceApplication.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : Controller
    {
        readonly IMediator _mediator;
        readonly UserManager<ApplicationUser> _userManager;
        public OrderItemController(IMediator mediator,UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        
        [HttpGet("{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int orderId)
        {
            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user.Id == null)
            {
                return Unauthorized();
            }
            var orderItems = await _mediator.Send(new GetOrderItemsQuery(orderId,user.Id));
            return Ok(orderItems);
        }

        
        [HttpPost]
        public async Task<ActionResult<OrderItem>> AddOrderItem(AddOrderItemCommand command)
        {
            var orderItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderItemById), new { orderItemId = orderItem.OrderItemId }, orderItem);
        }

        
        [HttpPut("{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderItemId,  UpdateOrderItemCommand command)
        {
            if (orderItemId != command.OrderItemId)
            {
                return BadRequest("Order item ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        
        [HttpDelete("{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderItemId)
        {
            var result = await _mediator.Send(new DeleteOrderItemCommand(orderItemId));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        
        [HttpGet("item/{orderItemId}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemById(int orderItemId)
        {
            var orderItem = await _mediator.Send(new GetOrderItemByIdQuery(orderItemId));
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
    }
}
