using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;


namespace ECommerceApplication.Application.Features.OrderItemFeature.Query.GetOrderItemsQuery
{

    public class GetOrderItemsQueryHandler : IRequestHandler<GetOrderItemsQuery, IEnumerable<OrderItem>>
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public GetOrderItemsQueryHandler(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> Handle(GetOrderItemsQuery request, CancellationToken cancellationToken)
        {
            return await _orderItemRepository.GetOrderItemsAsync(request.OrderId);
        }
    }
}
