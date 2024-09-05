using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VerstaIOAppliance.Entities;
using VerstaIOAppliance.Models;

namespace VerstaIOAppliance.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ApplicationContext _context;
    private readonly IMapper _mapper;

    public OrdersController(ApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> GetOrders()
    {
        var orders = await _context.Orders.ToListAsync();

        return Ok(_mapper.Map<List<OrderModel>>(orders));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(long id)
    {
        var order = await _context.Orders.FindAsync(id);
        
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
        
        _context.Orders.Add(_mapper.Map<OrderEntity>(orderModel));
        await _context.SaveChangesAsync();
        
        return Ok(orderModel);
    }
}
