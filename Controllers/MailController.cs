using App.Services.impl;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MailController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        Mail results = MailService.Get(id);
        return Ok(results);
    }
}