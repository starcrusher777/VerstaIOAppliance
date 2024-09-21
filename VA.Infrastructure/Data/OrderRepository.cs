using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VA.Domain.Entities;
using VA.Domain.Interfaces;
using VA.Infrastructure.Models;

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

    public async Task<OrderEntity> GetOrderAsync(long id)
    {
        return await _context.Orders.FindAsync(id);
    }
    
    public async Task<OrderEntity> CreateOrderAsync (OrderEntity order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(OrderEntity order)
    {
        await _context.Orders.AddAsync(order);
    }
    
}