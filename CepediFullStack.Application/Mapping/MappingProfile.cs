using AutoMapper;
using CepediFullStack.Application.Dtos;
using CepediFullStack.Application.Dtos.Customer;
using CepediFullStack.Application.Dtos.Order;
using CepediFullStack.Application.Dtos.Product;
using CepediFullStack.Application.Dtos.Status;
using CepediFullStack.Domain.Entities;

namespace CepediFullStack.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();

            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();

            CreateMap<Status, StatusResponse>();
            CreateMap<OrderRequest, Order>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId));
            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name));
        }
    }
}