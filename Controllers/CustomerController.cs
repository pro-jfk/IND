using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController: ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromServices] ICustomerService customerService,
        CreateCustomer createCustomer)
    {
        CustomerResponse? customer = await customerService.CreateCustomer(createCustomer);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Succes(customer);
        return Ok(result);
    }
}