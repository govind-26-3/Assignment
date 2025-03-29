using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;


namespace ECommerceApplication.Application.Features.OrderFeature.Command.AddCommand
{

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Orders>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Orders> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {        
            return await _orderRepository.AddOrderAsync(request.order);
        }
    }
}
