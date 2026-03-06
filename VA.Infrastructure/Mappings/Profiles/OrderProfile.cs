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
            .ForMember(x => x.Weight, opt => opt.MapFrom(y => double.Parse(y.Weight)))
            .ForMember(x => x.CreatedAt, opt => opt.MapFrom(y => DateTime.Parse(y.CreatedAt)))
            .ReverseMap()
            .ForMember(d => d.DeliveryDate, o => o.MapFrom(s => s.DeliveryDate.ToString("yyyy-MM-dd")))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss")))
            .ForMember(d => d.Weight, o => o.MapFrom(s => s.Weight.ToString(System.Globalization.CultureInfo.InvariantCulture)));
    }
}