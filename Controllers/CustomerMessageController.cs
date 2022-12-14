using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerMessageController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetCustomerMessage([FromServices] ICustomerMessageService customerMessageService, int customerId,
        int messageId)
    {
        CustomerMessageResponse customerMessage = await customerMessageService.GetCustomerMessage(customerId, messageId);
        ApiResult<CustomerMessageResponse> result =  ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }


    [HttpPatch]  
    public async Task<IActionResult> PatchCustomerMessagePrint([FromServices] ICustomerMessageService customerMessageService,
        int customerId, int messageId)
    {
        CustomerMessageResponse? customerMessage = await customerMessageService.UpdateCustomerMessagePrint(customerId, messageId);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchCustomerMessageReceived([FromServices] ICustomerMessageService customerMessageService,
        int customerId, int messageId)
    {
        CustomerMessageResponse customerMessage = await customerMessageService.UpdateCustomerMessageReceived(customerId, messageId);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }
    

}
