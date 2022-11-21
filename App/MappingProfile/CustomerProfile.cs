using App.Extensions;
using App.Models;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerModel, Customer>()
            .IgnoreDestination(c => c.DateAdded)
            .IgnoreDestination(c => c.Messages)
            .IgnoreDestination(c => c.EmergencyShelter)
            .IgnoreDestination(c => c.ID);
        
        CreateMap<Customer, CustomerResponse>();
    }
}