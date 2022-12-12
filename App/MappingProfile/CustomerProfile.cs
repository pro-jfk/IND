using App.Extensions;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class CustomerProfile : Profile
{
    /// <summary>
    /// Mapping of customer which ignores Dateadded and message when creating a new customer.
    /// </summary>
    public CustomerProfile()
    {
        CreateMap<CreateCustomer, Customer>();
        CreateMap<Customer, CustomerResponse>();
    }
}