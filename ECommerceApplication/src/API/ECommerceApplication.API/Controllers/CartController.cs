using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceApplication.Domain;
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

        // GET: api/cart/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems(int userId)
        {
            var cartItems = await _mediator.Send(new GetCartItemsQuery(userId));
            return Ok(cartItems);
        }

        // POST: api/cart
        [HttpPost]
        public async Task<ActionResult<CartItem>> AddCartItem([FromBody] AddCartItemCommand command)
        {
            var cartItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = cartItem.CartItemId }, cartItem);
        }

        // PUT: api/cart/{cartItemId}
        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(int cartItemId, [FromBody] UpdateCartItemCommand command)
        {
            if (cartItemId != command.CartItemId)
            {
                return BadRequest("Cart item ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/cart/{cartItemId}
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

        // GET: api/cart/item/{cartItemId}
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