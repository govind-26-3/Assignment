using MediatR;
using ECommerceApplication.Domain;
using ECommerceApplication.Application.Interfaces;

namespace ECommerceApplication.Application.Features.OrderFeature.Command.UpdateCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Orders>
    {
        readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Orders> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            if (request.order == null || request.order.OrderId <= 0)
            {
                throw new ArgumentException("Invalid order data.");
            }
            return await _orderRepository.UpdateOrderAsync(request.order.OrderId, request.order);
        }
    }
}

