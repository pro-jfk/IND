using App.Models;
using App.Services;
using App.Services.impl;
using Core.Entities.Mail;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MailController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IMailService mailService, int id)
    {
        Mail mail = await mailService.Get(id);
        ApiResult<Mail> results = ApiResult<Mail>.Succes(mail);
        return Ok(results);
    }
}