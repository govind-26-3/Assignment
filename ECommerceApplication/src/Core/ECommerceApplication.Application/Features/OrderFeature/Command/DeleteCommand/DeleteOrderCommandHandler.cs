

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
            return await _orderRepository.DeleteOrderAsync(request.id);
        }
    }
}
