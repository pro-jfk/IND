using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController: ApiController
{
    /// <summary>
    /// Post request that creates a new Customer.
    /// </summary>
    /// <param name="customerService"></param>
    /// <param name="createCustomer"></param>
    /// <returns>Type CustomerResponse from CustomerService</returns>
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromServices] ICustomerService customerService,
        CreateCustomer createCustomer)
    {
        CustomerResponse? customer = await customerService.CreateCustomer(createCustomer);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Succes(customer);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer([FromServices] ICustomerService customerService,
        int id)
    {
        CustomerResponse? customer = await customerService.GetCustomer(id);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Succes(customer);
        return Ok(result);
    }
    
    // [HttpGet]
    // public async Task<IActionResult> GetCustomers([FromServices] ICustomerService customerService)
    // {
    //     List<Customer> customer = await customerService.GetCustomers();
    //     ApiResult<List<Customer>> result = ApiResult<List<Customer>>.Succes(customer);
    //     return Ok(result);
    // }
}