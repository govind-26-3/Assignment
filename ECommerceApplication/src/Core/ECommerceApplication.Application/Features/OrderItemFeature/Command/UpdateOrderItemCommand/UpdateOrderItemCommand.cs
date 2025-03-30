using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItemFeature.Command.UpdateOrderItemCommand
{
    public record UpdateOrderItemCommand(int OrderItemId, int Quantity) : IRequest<OrderItem>;
}
