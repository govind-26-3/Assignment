using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.OrderFeature.Query.GetOrderByIdQuery
{
    //public record GetOrderByIdQuery(string id):IRequest<Orders>;
    public record GetOrderByIdQuery(int id) :IRequest<Orders>;
    
}
