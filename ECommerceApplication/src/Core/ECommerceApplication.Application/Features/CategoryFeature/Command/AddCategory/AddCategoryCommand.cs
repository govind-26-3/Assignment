
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.CategoryFeature.Command.AddCategory
{
    public record AddCategoryCommand(Category category) : IRequest<Category>
    {
    }
}
