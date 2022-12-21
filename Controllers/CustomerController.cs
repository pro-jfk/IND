using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost("{customerId}/fingerprint")]
    public async Task<IActionResult> PostFingerprint([FromServices] ICustomerService customerService, int customerId,
        string encodedFingerprint)
    {
        Console.Write($"Hello {customerId}{encodedFingerprint}");
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer([FromServices] ICustomerService customerService,
        int id)
    {
        CustomerResponse? customer = await customerService.GetCustomer(id);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Succes(customer);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCustomers([FromServices] ICustomerService customerService)
    {
        IEnumerable<CustomerResponse> customer = await customerService.GetCustomers();
        ApiResult<IEnumerable<CustomerResponse>> result = ApiResult<IEnumerable<CustomerResponse>>.Succes(customer);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromServices] ICustomerService customerService, CreateCustomer createCustomer)
    {
        CustomerResponse? customer = await customerService.UpdateCustomer(createCustomer);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Succes(customer);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer([FromServices] ICustomerService customerService, int id)
    {
        CustomerResponse? customer = await customerService.DeleteCustomer(id);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Succes(customer);
        return Ok(result);
    }
}