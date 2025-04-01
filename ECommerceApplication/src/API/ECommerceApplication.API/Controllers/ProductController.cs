using ECommerceApplication.Application.Features.ProductFeature.Command.AddProduct;
using ECommerceApplication.Application.Features.ProductFeature.Command.Delete;
using ECommerceApplication.Application.Features.ProductFeature.Query.GetAllProduct;
using ECommerceApplication.Application.Features.ProductFeature.Query.GetProductById;
using ECommerceApplication.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.API.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        readonly IMediator _mediator;


        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var allProducts = await _mediator.Send(new GetAllProductsQuery());
            return Ok(allProducts);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductsAsync(Product book)
        {
            var result = await _mediator.Send(new AddProductCommand(book));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);

        }
    }
}
