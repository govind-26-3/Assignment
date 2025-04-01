using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderFeature.Command.AddCommand
{
    public record AddOrderCommand(string UserId, int quantity, int ProductId) : IRequest<Orders>;
}
    

