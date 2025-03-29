using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderFeature.Command.DeleteCommand
{
    public record DeleteOrderCommand(int id) : IRequest<bool>;
    
}
