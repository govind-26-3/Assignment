using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CategoryFeature.Query.GetCategoryById
{
    public record GetCategoryByIdQuery(int id):IRequest<Category>;
    
}
