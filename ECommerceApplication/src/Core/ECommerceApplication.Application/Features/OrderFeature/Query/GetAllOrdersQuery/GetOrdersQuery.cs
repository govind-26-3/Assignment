using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderFeature.Query.GetAllOrdersQuery
{
    public record GetOrdersQuery() : IRequest<IEnumerable<Orders>>;
    
}