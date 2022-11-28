using App.Models;
using App.Responses;
using App.Services;
using Data;
using Data.Repositories.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class MessageController : ApiController
{
    /// <summary>
    /// Get message from MessageService
    /// </summary>
    /// <param name="messageService"></param>
    /// <param name="id"></param>
    /// <returns>Type MessageRepsonse from MessageService</returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMessage([FromServices] IMessageService messageService, int id)
    {
        MessageResponse? message = await messageService.GetMessage(id);
        ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Succes(message);
        return Ok(result);
    }
}