using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CartFeature.Query.GetCartItemByIdQueryHandler
{
    public class GetCartItemByIdQueryHandler : IRequestHandler<GetCartItemByIdQuery, CartItem>
    {
        private readonly ICartRepository _cartRepository;

        public GetCartItemByIdQueryHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await _cartRepository.GetCartItemByIdAsync(request.CartItemId);
        }
    }
}
