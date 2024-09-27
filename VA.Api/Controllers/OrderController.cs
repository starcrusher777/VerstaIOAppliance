using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VA.Application.Services;
using VA.Domain.Entities;
using VA.Infrastructure.Models;

namespace VA.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;
    private readonly IMapper _mapper;

    public OrdersController(OrderService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _service.GetOrdersAsync();

        if (!orders.Any())
        {
            return Ok("No orders found");
        }
        
        return Ok(_mapper.Map<List<OrderModel>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(long id)
    {
        var order = await _service.GetOrderAsync(id);
        
        if (order == null)
        {
            return NotFound($"Order with id '{id}' not found!");
        }

        return Ok(_mapper.Map<OrderModel>(order));
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(OrderModel order)
    {
        await _service.CreateOrderAsync(order);
        
        return Ok(_mapper.Map<OrderModel>(order));
    }
}