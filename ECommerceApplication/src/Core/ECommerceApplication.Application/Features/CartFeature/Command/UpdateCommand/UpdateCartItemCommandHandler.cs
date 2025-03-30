
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;


namespace ECommerceApplication.Application.Features.CartFeature.Command.UpdateCommand
{
    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public UpdateCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = new CartItem
            {
                CartItemId = request.CartItemId,
                Quantity = request.Quantity
                
            };

            return await _cartRepository.UpdateCartItemAsync(request.CartItemId, cartItem);
        }
    }
}
