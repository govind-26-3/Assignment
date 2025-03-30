using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItemFeature.Command.UpdateOrderItemCommand
{

    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, OrderItem>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public UpdateOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem
            {
                OrderItemId = request.OrderItemId,
                Quantity = request.Quantity
                
            };

            return await _orderItemRepository.UpdateOrderItemAsync(request.OrderItemId, orderItem);
        }
    }
}
