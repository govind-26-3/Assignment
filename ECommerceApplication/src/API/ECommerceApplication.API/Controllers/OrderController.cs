﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using ECommerceApplication.Domain;
using ECommerceApplication.Application.Features.OrderFeature.Command.UpdateCommand;
using ECommerceApplication.Application.Features.OrderFeature.Query.GetAllOrdersQuery;
using ECommerceApplication.Application.Features.OrderFeature.Query.GetOrderByIdQuery;
using ECommerceApplication.Application.Features.OrderFeature.Command.AddCommand;
using ECommerceApplication.Application.Features.OrderFeature.Command.DeleteCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ECommerceApplication.Identity.Model;
using ECommerceApplication.Infrastructure.Context;
using ECommerceApplication.Domain.Constants;
using Microsoft.EntityFrameworkCore;
using ECommerceApplication.Application.Features.OrderFeature.Query.GetOrdersByUserIdQuery;

namespace ECommerceApplication.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
         readonly IMediator _mediator;
         readonly EcommerceDbContext _ecommerceDbContext;
         readonly UserManager<ApplicationUser> _userManager; 

        public OrderController(IMediator mediator, UserManager<ApplicationUser> userManager,EcommerceDbContext ecommerceDbContext)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            var orders = await _mediator.Send(new GetOrdersQuery());
            return Ok(orders);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrderById(int id)
        {

            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        //public async Task<ActionResult<Orders>> GetOrderById(string id)
       
        //[HttpPost]
        //public async Task<ActionResult<Orders>> AddOrder([FromQuery] int productId, [FromBody] int quantity)
        //{
        //    var userEmail = _userManager.GetUserId(User);
        //    var user = await _userManager.FindByEmailAsync(userEmail);
        //    if (user.Id == null)
        //    {
        //        return Unauthorized(); 
        //    }
        //    var addOrderCommand = new AddOrderCommand(user.Id, quantity, productId);
        //    var order = await _mediator.Send(addOrderCommand);
        //    return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        //}

        [HttpPost]
        public async Task<ActionResult<Orders>> AddOrder([FromBody] int cartItemId)
        {
            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user.Id == null)
            {
                return Unauthorized(); 
            }
            //var addOrderCommand = new AddOrderCommand(user.Id, quantity, productId);
            var addOrderCommand = new AddOrderCommand(cartItemId);

            var order = await _mediator.Send(addOrderCommand);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id,  UpdateOrderCommand command)
        {
            if (id != command.order.OrderId)
            {
                return BadRequest("Order ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("myOrders")]
        public async Task<ActionResult<IEnumerable<Orders>>> MyOrders()
        {

            var userEmail = _userManager.GetUserId(User);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user.Id == null)
            {
                return Unauthorized();
            }
            var orders = await _mediator.Send(new GetOrdersByUserIdQuery(user.Id));

            if (orders == null || !orders.Any()) 
            {
                return NotFound();
            }

            return Ok(orders);

        }
    }
}