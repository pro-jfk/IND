using App.Auth;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class CustomerController : ApiController
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
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Success(customer);
        return Ok(result);
    }

    //
    // [HttpPost("{id}/fingerprint")]
    // public async Task<IActionResult> PostFingerprint([FromServices] ICustomerService customerService, int id,
    //     string fingerprint)
    // {
    //     bool verified = await customerService.VerifyFingerprint(id, fingerprint);
    //     ApiResult<bool> result = ApiResult<bool>.Success(verified);
    //     return Ok(result);
    //     
    // }
    [Authorize(Roles = UserRoles.User)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer([FromServices] ICustomerService customerService,
        int id)
    {
        CustomerResponse? customer = await customerService.GetCustomer(id);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Success(customer);
        return Ok(result);
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetCustomers([FromServices] ICustomerService customerService)
    {
        IEnumerable<CustomerResponse> customer = await customerService.GetCustomers();
        ApiResult<IEnumerable<CustomerResponse>> result = ApiResult<IEnumerable<CustomerResponse>>.Success(customer);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromServices] ICustomerService customerService,
        CreateCustomer createCustomer)
    {
        CustomerResponse? customer = await customerService.UpdateCustomer(createCustomer);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Success(customer);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer([FromServices] ICustomerService customerService, int id)
    {
        CustomerResponse? customer = await customerService.DeleteCustomer(id);
        ApiResult<CustomerResponse> result = ApiResult<CustomerResponse>.Success(customer);
        return Ok(result);
    }


    [HttpPost("{id}/fingerprintcheck")]
    public async Task<bool> VerifyFingerprint([FromServices] ICustomerService customerService, int id)
    {
        bool answer = await customerService.VerifyFingerprintArduino(id);
        Console.WriteLine(answer);
        return answer;
    }

    //For Prototype purposes
    [HttpPost("{id}/fingerprintcheck-arduino")]
    public async Task<bool> VerifyFingerprintArduino([FromServices] ICustomerService customerService, int id)
    {
        bool answer = await customerService.VerifyFingerprintArduino(id);
        Console.WriteLine(answer);
        return answer;
    }
}