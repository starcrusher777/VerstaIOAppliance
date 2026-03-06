using AutoMapper;
using VA.Domain.Entities;
using VA.Domain.Interfaces;
using VA.Infrastructure.Models;

namespace VA.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderEntity> CreateOrderAsync(OrderModel orderModel)
    {
        var orderEntity = _mapper.Map<OrderEntity>(orderModel);
        return await _orderRepository.CreateOrderAsync(orderEntity);
    }

    public async Task<List<OrderEntity>> GetOrdersAsync()
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task<OrderEntity?> GetOrderAsync(long id)
    {
        return await _orderRepository.GetOrderAsync(id);
    }
}