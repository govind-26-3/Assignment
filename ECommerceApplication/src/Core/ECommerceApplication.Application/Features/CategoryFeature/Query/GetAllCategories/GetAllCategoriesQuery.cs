using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CategoryFeature.Query.GetAllCategories
{
    public class GetAllCategoriesQuery(): IRequest<IEnumerable<Category>>;
    
    
}
