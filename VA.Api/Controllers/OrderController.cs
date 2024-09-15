using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VA.Application.Services;
using VA.Infrastructure.Data;
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
        var orders = await _service.GetOrders();

        if (!orders.Any())
        {
            return NotFound("No orders found!");
        }
        
        return Ok(_mapper.Map<List<OrderModel>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(long id)
    {
        var order = await _service.GetOrderById(id);
        
        if (order == null)
        {
            return NotFound($"Order with id '{id}' not found!");
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOrder(OrderModel order)
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
        
        _service.CreateOrder(_mapper.Map<OrderModel>(orderModel));
        _service.SaveChanges();
        
        return Ok(orderModel);
    }
}