using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderFeature.Query.GetOrdersByUserIdQuery
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, IEnumerable<Orders>>
    {
        readonly IOrderRepository _orderRepository;
        public GetOrdersByUserIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<IEnumerable<Orders>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrdersByUserIdAsync(request.id);
        }
    }
}
