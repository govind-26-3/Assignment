using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CartFeature.Query.GetCartItemByIdQueryHandler
{
    public record GetCartItemByIdQuery(int CartItemId) : IRequest<CartItem>;
}