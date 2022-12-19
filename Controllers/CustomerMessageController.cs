using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerMessageController : ApiController
{
    [HttpGet("{customerId}/{messageId}")]
    public async Task<IActionResult> GetCustomerMessage([FromServices] ICustomerMessageService customerMessageService, int customerId,
        int messageId)
    {
        CustomerMessageResponse customerMessage = await customerMessageService.GetCustomerMessage(customerId, messageId);
        ApiResult<CustomerMessageResponse> result =  ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerMessages([FromServices] ICustomerMessageService customerMessageService)
    {
        IEnumerable<CustomerMessageResponse> customerMessages = await customerMessageService.GetCustomerMessages();
        ApiResult<IEnumerable<CustomerMessageResponse>> result = ApiResult<IEnumerable<CustomerMessageResponse>>.Succes(customerMessages);
        return Ok(result);
    }

    [HttpPatch("{customerId}/{messageId}/printjob")]  
    public async Task<IActionResult> PatchCustomerMessagePrintJob([FromServices] ICustomerMessageService customerMessageService,
        int customerId, int messageId, bool statusPrinted)
    {
        CustomerMessageResponse? customerMessage = await customerMessageService.UpdateCustomerMessagePrintJob(customerId, messageId, statusPrinted);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }

    [HttpPatch("{customerId}/{messageId}/received")]
    public async Task<IActionResult> PatchCustomerMessageReceived([FromServices] ICustomerMessageService customerMessageService,
        int customerId, int messageId, DateTime dateTime, bool statusReceived)
    {
        CustomerMessageResponse customerMessage = await customerMessageService.UpdateCustomerMessageReceived(customerId, messageId, dateTime, statusReceived);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCustomerMessage(
        [FromServices] ICustomerMessageService customerMessageService, int customerId, int messageId )
    {
        CustomerMessageResponse customerMessage =
            await customerMessageService.DeleteCustomerMessage(customerId, messageId);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }


}
