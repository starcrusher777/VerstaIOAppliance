using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VA.Application.Services;
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
            return NotFound("No orders found!");
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

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(OrderModel order)
    {
        try
        {
            var orderModel = new OrderModel
            {
                SenderCity = order.SenderCity,
                SenderAddress = order.SenderAddress,
                RecipientCity = order.RecipientCity,
                RecipientAddress = order.RecipientAddress,
                Weight = order.Weight,
                DeliveryDate = order.DeliveryDate
            };

            _service.CreateOrderAsync(_mapper.Map<OrderModel>(orderModel));
            _service.SaveChangesAsync();

            return Ok(orderModel);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}