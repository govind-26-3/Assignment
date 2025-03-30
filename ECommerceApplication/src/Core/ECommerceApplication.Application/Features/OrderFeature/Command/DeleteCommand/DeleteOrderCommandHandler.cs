

using ECommerceApplication.Application.Exceptions;
using ECommerceApplication.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace ECommerceApplication.Application.Features.OrderFeature.Command.DeleteCommand
{

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
         readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            var orderFindStatus = await _orderRepository.GetOrderByIdAsync(request.id);
            if (orderFindStatus is null)
            {
                throw new NotFoundException($"Order with Id::{request.id} not found");

            }
            return await _orderRepository.DeleteOrderAsync(orderFindStatus.OrderId);

        }
    }
}
