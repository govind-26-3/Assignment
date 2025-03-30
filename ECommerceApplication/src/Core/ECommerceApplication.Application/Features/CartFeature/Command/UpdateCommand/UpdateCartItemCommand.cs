
using MediatR;
using ECommerceApplication.Domain;

namespace ECommerceApplication.Application.Features.CartFeature.Command.UpdateCommand
{

    public record UpdateCartItemCommand(int CartItemId, int Quantity) : IRequest<CartItem>;
}
