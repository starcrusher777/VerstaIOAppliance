using Microsoft.AspNetCore.Mvc;
using VA.Infrastructure.Entities;

namespace VA.Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<OrderEntity>> GetOrdersAsync();
    Task<ActionResult<OrderEntity>> GetOrder(long id);
    Task<ActionResult<OrderEntity>> CreateOrder(OrderEntity order);
    void Add(OrderEntity order);
    void SaveChanges();
}