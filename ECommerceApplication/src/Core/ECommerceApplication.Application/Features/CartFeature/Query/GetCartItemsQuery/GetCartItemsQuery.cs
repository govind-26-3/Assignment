using MediatR;
using ECommerceApplication.Domain;

namespace ECommerceApplication.Application.Features.CartFeature.Query.GetCartItemsQuery
{
    public record GetCartItemsQuery(string UserId) : IRequest<IEnumerable<CartItem>>;
}
