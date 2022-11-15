using App.Models;
using App.Services;
using App.Services.impl;
using Core.Entities.Mail;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MailStatusController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IMailStatusService  mailStatusService, int id)
    {
        MailStatus mailStatus = await mailStatusService.Get(id);
        ApiResult<MailStatus> results = ApiResult<MailStatus>.Succes(mailStatus);
        return Ok(results);
    }
}
