using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

public class MessageController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateMessage([FromServices] IMessageService messageService,
        CreateMessage createMessage)
    {
        MessageResponse? message = await messageService.CreateMessage(createMessage);
        ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Success(message);
        return Ok(result);
    }

    /// <summary>
    /// Get message from MessageService
    /// </summary>
    /// <param name="messageService">TEntity</param>
    /// <param name="id">Int</param>
    /// <returns>Type MessageResponse from MessageService</returns>
    /// TODO Add param types, look at id for example
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMessage([FromServices] IMessageService messageService, int id)
    {
        MessageResponse? message = await messageService.GetMessage(id );
        ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Success(message);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetMessages([FromServices] IMessageService messageService)
    {
        IEnumerable<MessageResponse> message = await messageService.GetMessages();
        ApiResult<IEnumerable<MessageResponse>> result = ApiResult<IEnumerable<MessageResponse>>.Success(message);
        return Ok(result);
    }
    
    [HttpGet("{customerId}/messages")]
    public async Task<IActionResult> GetMessages([FromServices] IMessageService messageService, int customerId)
    {
        IEnumerable<MessageResponse> messages = await messageService.GetMessagesForCustomer(customerId);
        ApiResult<IEnumerable<MessageResponse>> result = ApiResult<IEnumerable<MessageResponse>>.Success(messages);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMessage([FromServices] IMessageService messageService,
        CreateMessage updateMessage)
    {
        MessageResponse? message = await messageService.UpdateMessage(updateMessage);
        ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Success(message);
        return Ok(result);
    }
    
         [HttpPatch("{customerId}/{messageId}/print-job")]  
     public async Task<IActionResult> PatchMessagePrintJob([FromServices] IMessageService messageService,
         int customerId, int messageId, bool statusPrinted)
     {
         MessageResponse message = await messageService.UpdateMessagePrintJob(customerId, messageId, statusPrinted);
         ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Success(message);
         return Ok(result);
     }

     [HttpPatch("{customerId}/{messageId}/received")]
     public async Task<IActionResult> PatchMessageReceived([FromServices] IMessageService messageService,
         int customerId, int messageId, DateTime dateTime, bool statusReceived)
     {
         MessageResponse message = await messageService.UpdateMessageReceived(customerId, messageId, dateTime, statusReceived);
         ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Success(message);
         return Ok(result);
     }


    [HttpDelete]
    public async Task<IActionResult> DeleteMessage([FromServices] IMessageService messageService, int id)
    {
        MessageResponse? message = await messageService.DeleteMessage(id);
        ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Success(message);
        return Ok(result);
    }
}