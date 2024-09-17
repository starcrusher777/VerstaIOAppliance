using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VA.Domain.Interfaces;
using VA.Infrastructure.Entities;
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

    public async Task<OrderModel> CreateOrderAsync (OrderModel order)
    {
        var orderEntity = _mapper.Map<OrderEntity>(order);

        await _orderRepository.AddAsync(orderEntity);
        await _orderRepository.SaveChangesAsync();

        return order;
    }

    public async Task<List<OrderModel>> GetOrdersAsync()
    {
        var orders = await _orderRepository.GetOrdersAsync();
        return _mapper.Map<List<OrderModel>>(orders);
    }

    public async Task<OrderModel> GetOrderAsync(long id)
    {
        var orderEntity = await _orderRepository.GetOrderAsync(id);
        return _mapper.Map<OrderModel>(orderEntity);
    }
}