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

    public async Task<OrderModel> CreateOrder (OrderModel order)
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
        
        _orderRepository.Add(_mapper.Map<OrderEntity>(orderModel));
        _orderRepository.SaveChanges();

        return order;
    }

    public async Task<List<OrderEntity>> GetOrders()
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task<Task<ActionResult<OrderEntity>>> GetOrderById(long id)
    {
        return _orderRepository.GetOrder(id);
    }

    public async Task SaveChanges()
    {
        _orderRepository.SaveChanges();
    }
}