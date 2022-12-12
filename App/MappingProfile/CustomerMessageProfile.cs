using App.Extensions;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;


public class CustomerMessageProfile : Profile
{
    public CustomerMessageProfile()
    {
        CreateMap<CreateCustomerMessage, CustomerMessage>()
            .IgnoreDestination(cm => cm.DateReceived)
            .IgnoreDestination(cm =>cm.MessageId);
        
        CreateMap<CustomerMessage, CustomerMessageResponse>();
    }
}

