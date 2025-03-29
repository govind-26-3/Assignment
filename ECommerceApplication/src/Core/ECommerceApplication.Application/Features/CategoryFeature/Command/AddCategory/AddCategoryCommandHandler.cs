using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CategoryFeature.Command.AddCategory
{
    internal class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
    {
        readonly ICategoryRepository _categoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.AddCategoryAsync(request.category);
            return category;
        }
    }
}
