using Microsoft.AspNetCore.Mvc;
using VA.Infrastructure.Entities;

namespace VA.Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<OrderEntity>> GetOrdersAsync();
    Task<OrderEntity> GetOrderAsync(long id);
    Task CreateOrderAsync (OrderEntity order);
    Task AddAsync(OrderEntity order);
    Task SaveChangesAsync();
}