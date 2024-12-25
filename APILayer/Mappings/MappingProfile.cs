using AutoMapper;
using DataLayer;
using APILayer.DTOs;

namespace APILayer.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<CreateProductDTO, Product>();

        CreateMap<Order, OrderDTO>();
        CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<OrderItem, OrderItemDTO>();
        CreateMap<CreateOrderItemDTO, OrderItem>();

        CreateMap<User, UserDTO>();
        CreateMap<CreateUserDTO, User>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}