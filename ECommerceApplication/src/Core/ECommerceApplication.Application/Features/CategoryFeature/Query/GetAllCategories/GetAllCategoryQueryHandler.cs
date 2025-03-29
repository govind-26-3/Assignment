using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CategoryFeature.Query.GetAllCategories
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        readonly ICategoryRepository _categoryRepository;
        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategories();

        }
    }
}
