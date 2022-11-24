using App.Models;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace App.Services.impl;


public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    
    public async Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer)
    {
        Customer customer = _mapper.Map<Customer>(createCustomer);
        customer.DateAdded = DateTime.Now;
        Customer result = await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerResponse>(result);
    }
}