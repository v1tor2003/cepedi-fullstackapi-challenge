using AutoMapper;
using CepediFullStack.Application.Dtos;
using CepediFullStack.Application.Dtos.Customer;
using CepediFullStack.Domain.Entities;

namespace CepediFullStack.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<Customer, CustomerResponse>();
        }
    }
}