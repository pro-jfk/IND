using App.Models;
using App.Responses;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerMessageController : ApiController
{
    [HttpGet]
    public async Task<string[]> GetMessage()
    {
        string[] test = { "hello", " world", "!" };
        return test;
    }

    [HttpPost]  
    public async Task<IActionResult> CreateCustomerMessage([FromServices] ICustomerMessageService customerMessageService,
        CreateCustomerMessage createCustomerMessage)
    {
        CustomerMessageResponse? customerMessage = await customerMessageService.CreateCustomerMessage(createCustomerMessage);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }
}
