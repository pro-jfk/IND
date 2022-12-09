using App.Models;
using App.Responses;
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
    /// <summary>
    /// Create customer from the CustomerRepository
    /// </summary>
    /// <param name="createCustomer">CreateCustomer</param>
    /// <returns>Type: CustomerResponse</returns>
    public async Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer)
    {
        Customer customer = _mapper.Map<Customer>(createCustomer);
        customer.DateAdded = DateTime.Now;
        Customer result = await _customerRepository.AddAsync(customer);
        return _mapper.Map<CustomerResponse>(result);
    }

    public async Task<CustomerResponse> GetCustomer(int id)
    {
        Customer result = await _customerRepository.GetFirstASync(c => c.Id == id);
        return _mapper.Map<CustomerResponse>(result);
    }
    
    public async Task<List<Customer>> GetCustomers()
    {
        List<Customer> result = await _customerRepository.GetAllAsync();
        return result;
    }

    // public async Task<CustomerResponse> UpdateCustomer(UpdateCustomer updateCustomer)
    // {
    //     Customer customer = _mapper
    // }
    //
    // public async Task<CustomerResponse> DeleteCustomer(DeleteCustomer deleteCustomer)
    // {
    //     Customer result = async 
    // }
}