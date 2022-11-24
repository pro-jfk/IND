using App.Models;

namespace App.Services;

public interface ICustomerService
{
    Task<CustomerResponse> CreateCustomer(CreateCustomer createCustomer);
}