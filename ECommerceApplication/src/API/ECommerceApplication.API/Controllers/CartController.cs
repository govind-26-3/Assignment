using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceApplication.Domain;
using ECommerceApplication.Application.Features.CartFeature.Query.GetCartItemByIdQueryHandler;
using ECommerceApplication.Application.Features.CartFeature.Command.DeleteCommand;
using ECommerceApplication.Application.Features.CartFeature.Command.UpdateCommand;
using ECommerceApplication.Application.Features.CartFeature.Command.AddCommand;
using ECommerceApplication.Application.Features.CartFeature.Query.GetCartItemsQuery;
namespace ECommerceApplication.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(int userId)
        {
            var cartItems = await _mediator.Send(new GetCartItemsQuery(userId));
            return Ok(cartItems);
        }

        
        [HttpPost]
        public async Task<ActionResult<CartItem>> AddCartItem( AddCartItemCommand command)
        {
            var cartItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItem.CartItemId }, cartItem);
        }

        
        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, UpdateCartItemCommand command)
        {
            if (cartItemId != command.CartItemId)
            {
                return BadRequest("Cart item ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        
        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            var result = await _mediator.Send(new DeleteCartItemCommand(cartItemId));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        
        [HttpGet("item/{cartItemId}")]
        public async Task<ActionResult<CartItem>> GetCartItemById(int cartItemId)
        {
            var cartItem = await _mediator.Send(new GetCartItemByIdQuery(cartItemId));
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }
    }
}