using AutoMapper;
using CepediFullStack.Application.Dtos;
using CepediFullStack.Application.Dtos.Customer;
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
        }
    }
}