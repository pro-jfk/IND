using App.Models;
using App.Responses;
using Core.Entities;

namespace App.Services;

public interface ICustomerService
{
    Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer);
    Task<CustomerResponse> GetCustomer(int id);

    Task<List<Customer>> GetCustomers();
    // Task<CustomerResponse> UpdateCustomer(UpdateCustomer updateCustomer);
    // Task<CustomerResponse> DeleteCustomer(DeleteCustomer deleteCustomer);
}