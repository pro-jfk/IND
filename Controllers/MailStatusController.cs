using App.Services.impl;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MailStatusController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        MailStatus results = MailStatusService.Get(id);
        return Ok(results);
    }
}
