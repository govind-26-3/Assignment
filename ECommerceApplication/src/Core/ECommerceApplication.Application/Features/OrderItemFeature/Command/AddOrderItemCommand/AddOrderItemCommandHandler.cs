using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItemFeature.Command.AddOrderItemCommand
{

    public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, OrderItem>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public AddOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.AddOrderItemAsync(request.OrderItem);
        }
    }
}
