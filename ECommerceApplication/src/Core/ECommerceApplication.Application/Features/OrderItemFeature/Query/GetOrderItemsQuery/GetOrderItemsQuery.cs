using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItemFeature.Query.GetOrderItemsQuery
{
    public record GetOrderItemsQuery(int OrderId,string userId) : IRequest<IEnumerable<OrderItem>>;
}
