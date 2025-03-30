using MediatR;
using ECommerceApplication.Domain;
namespace ECommerceApplication.Application.Features.CartFeature.Command.AddCommand
{
    public record AddCartItemCommand(CartItem CartItem) : IRequest<CartItem>;
}