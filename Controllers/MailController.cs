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

    [HttpPost]
    public async Task<IActionResult> Post([FromServices] IMailService mailService, string message, int vNumber)
    {
        var mail = new Mail()
        {
            Message = message,
            Vnumber = vNumber,
            MailStatus = new MailStatus()
            {
                VNumber = vNumber,
                DateSent = "",
                Message = "",
            }
        };
        
        Mail mail2 = await mailService.CreateMail(mail);
        ApiResult<Mail> results = ApiResult<Mail>.Succes(mail2);
        return Ok(results);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromServices] IMailService mailService, int id)
    {
        var result = await mailService.DeleteMail(id);

        return result ? Ok() : NotFound();
    }
}