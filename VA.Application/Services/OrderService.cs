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

    public async Task CreateOrderAsync(OrderModel orderModel)
    {
        var orderEntity = _mapper.Map<OrderEntity>(orderModel);
        await _orderRepository.CreateOrderAsync(orderEntity);
    }

    public async Task<List<OrderEntity>> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync();
        return _mapper.Map<List<OrderEntity>>(orders);
    }

    public async Task<OrderEntity?> GetOrderAsync(long id)
    {
        var order = await _orderRepository.GetOrderAsync(id);
        return _mapper.Map<OrderEntity>(order);
    }
}