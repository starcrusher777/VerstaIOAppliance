using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VA.Infrastructure.Entities;
using VA.Infrastructure.Models;

namespace VA.Infrastructure.Data;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationContext _context;

    public OrderRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<OrderEntity>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<OrderEntity> GetOrderById(long id)
    {
        return _context.Orders.Find(id);
    }
    
    public void CreateOrder(OrderEntity order)
    {
        _context.Orders.Add(order);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Add(OrderEntity order)
    {
        _context.Orders.Add(order);
    }
    
}