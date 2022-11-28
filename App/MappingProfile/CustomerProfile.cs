using App.Extensions;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomer, Customer>()
            .IgnoreDestination(c => c.DateAdded)
            .IgnoreDestination(c => c.Messages);
        
        CreateMap<Customer, CustomerResponse>();
    }
}