using AutoMapper;
using VerstaIOAppliance.Entities;
using VerstaIOAppliance.Models;

namespace VerstaIOAppliance.Mappings;

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