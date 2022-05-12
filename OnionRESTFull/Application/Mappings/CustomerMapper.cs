using Application.DTOs;
using Application.Features.Customer.Commands.CreateCustomerCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>();

            CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}