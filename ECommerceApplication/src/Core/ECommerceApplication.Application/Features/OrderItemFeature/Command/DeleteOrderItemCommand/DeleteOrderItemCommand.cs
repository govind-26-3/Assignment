
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItemFeature.Command.DeleteOrderItemCommand
{
    public record DeleteOrderItemCommand(int OrderItemId) : IRequest<bool>;
}
