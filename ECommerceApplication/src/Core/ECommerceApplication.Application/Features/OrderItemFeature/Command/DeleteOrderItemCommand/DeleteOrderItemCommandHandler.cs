
using ECommerceApplication.Application.Exceptions;
using ECommerceApplication.Application.Interfaces;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderItemFeature.Command.DeleteOrderItemCommand
{


    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, bool>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public DeleteOrderItemCommandHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<bool> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            var OrderItemFindStatus = await _orderItemRepository.GetOrderItemByIdAsync(request.OrderItemId);
            if (OrderItemFindStatus is null)
            {
                throw new NotFoundException($"OrderItem with Id::{request.OrderItemId} not found");

            }

            return await _orderItemRepository.DeleteOrderItemAsync(OrderItemFindStatus.OrderItemId);


        }
    }
}
