
using MediatR;

namespace ECommerceApplication.Application.Features.CartFeature.Command.DeleteCommand
{
    public record DeleteCartItemCommand(int CartItemId) : IRequest<bool>;
}
