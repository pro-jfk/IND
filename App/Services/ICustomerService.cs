using App.Models;
using App.Responses;

namespace App.Services;

public interface ICustomerService
{
    Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer);
}