using App.Models;
using App.Responses;
using Core.Entities;

namespace App.Services;

public interface ICustomerService
{
    Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer);
    Task<CustomerResponse> GetCustomer(int id);
    Task<IEnumerable<CustomerResponse>> GetCustomers();
    Task<CustomerResponse> UpdateCustomer(CreateCustomer createCustomer);
    Task<CustomerResponse> DeleteCustomer(int id);
}