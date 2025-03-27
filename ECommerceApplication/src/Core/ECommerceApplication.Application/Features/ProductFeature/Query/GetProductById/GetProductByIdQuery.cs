using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.ProductFeature.Query.GetProductById
{
    public record GetProductByIdQuery(int id): IRequest<Product>;
    
}
