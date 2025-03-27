using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApplication.Application.Interfaces;
using ECommerceApplication.Domain;
using MediatR;

namespace ECommerceApplication.Application.Features.ProductFeature.Command.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        readonly IProductRepository _repository;

        public AddProductCommandHandler(IProductRepository repository) { 
        
            _repository=repository;
        }
        public Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.AddProductAsync(request.product);
            return product;
        }
    }
}
