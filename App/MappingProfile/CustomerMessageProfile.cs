using App.Extensions;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class CustomerMessageProfile : Profile
{
    public CustomerMessageProfile()
    {
        CreateMap<CreateCustomerMessage, CustomerMessage>()
            .IgnoreDestination(cm => cm.DateReceived);

        CreateMap<CustomerMessage, CustomerMessageResponse>();
    }
}