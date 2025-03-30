using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

using ECommerceApplication.Domain;
using ECommerceApplication.Application.Features.CategoryFeature.Query.GetAllCategories;
using ECommerceApplication.Application.Features.CategoryFeature.Query.GetCategoryById;
using ECommerceApplication.Application.Features.CategoryFeature.Command.AddCategory;
using ECommerceApplication.Application.Features.CategoryFeature.Command.DeleteCategory;

namespace ECommerceApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
         readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(AddCategoryCommand command)
        {
            var category = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.CId }, category);
        }

        
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCategory(int id,  UpdateCategoryCommand command)
        //{
        //    if (id != command.CId)
        //    {
        //        return BadRequest("Category ID mismatch");
        //    }

        //    await _mediator.Send(command);
        //    return NoContent();
        //}

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}