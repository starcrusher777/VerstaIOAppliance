using AutoMapper;
using VA.Domain.Entities;
using VA.Infrastructure.Models;


namespace VA.Infrastructure.Mappings.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderModel, OrderEntity>()
            .ForMember(x => x.DeliveryDate, opt => opt.MapFrom(y => DateTime.Parse(y.DeliveryDate)))
            .ForMember(x => x.Weight, opt => opt.MapFrom(y => Double.Parse(y.Weight)))
            .ReverseMap();
    }
}