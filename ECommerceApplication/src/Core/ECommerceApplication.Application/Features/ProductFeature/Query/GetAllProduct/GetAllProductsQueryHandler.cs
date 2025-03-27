using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.ProductFeature.Query.GetAllProduct
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        readonly IProductRepository _repository;

        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _repository.GetProducts();
            return allProducts;
        }
    }
}
