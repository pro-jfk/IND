using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace App.Services.impl;

public class CustomerMessageService : ICustomerMessageService
{
    private readonly ICustomerMessageRepository _customerMessageRepository;
    private readonly IMapper _mapper;
 
    public CustomerMessageService(ICustomerMessageRepository customerMessageRepository, IMapper mapper)
    {
        _customerMessageRepository = customerMessageRepository;
        _mapper = mapper;
    }
    public async Task<CustomerMessageResponse> CreateCustomerMessage(CreateCustomerMessage createCustomerMessage)
    {
        CustomerMessage customerMessage = _mapper.Map<CustomerMessage>(createCustomerMessage);
        customerMessage.CustomerId = 1;
        return NotImplementedException;
    }

    public CustomerMessageResponse NotImplementedException { get; }
}