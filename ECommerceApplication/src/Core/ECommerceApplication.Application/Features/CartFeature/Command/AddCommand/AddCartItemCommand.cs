using MediatR;
using ECommerceApplication.Domain;
namespace ECommerceApplication.Application.Features.CartFeature.Command.AddCommand
{
    public record AddCartItemCommand(string userId,int quantity,int productId) : IRequest<CartItem>;
}