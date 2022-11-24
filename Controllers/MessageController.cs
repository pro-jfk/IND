using App.Models;
using App.Services;
using Data;
using Data.Repositories.Impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class MessageController : ApiController
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMessage([FromServices] IMessageService messageService, int id)
    {
        MessageResponse? message = await messageService.GetMessage(id);
        ApiResult<MessageResponse> result = ApiResult<MessageResponse>.Succes(message);
        return Ok(result);
    }
}