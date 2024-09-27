using Microsoft.EntityFrameworkCore;
using VA.Domain.Entities;
using VA.Domain.Interfaces;

namespace VA.Infrastructure.Data;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<OrderEntity>> GetOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<OrderEntity?> GetOrderAsync(long id)
    {
        return await _context.Orders.FindAsync(id);
    }
    
    public async Task<OrderEntity> CreateOrderAsync (OrderEntity orderEntity)
    {
        await _context.Orders.AddAsync(orderEntity);
        await _context.SaveChangesAsync();
        return orderEntity;
    }
    
}