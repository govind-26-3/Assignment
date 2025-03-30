using MediatR;
using ECommerceApplication.Domain;

namespace ECommerceApplication.Application.Features.CartFeature.Query.GetCartItemsQuery
{
    public record GetCartItemsQuery(int UserId) : IRequest<IEnumerable<CartItem>>;
}
