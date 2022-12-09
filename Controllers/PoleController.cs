using App.Models;
using App.Responses;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PoleController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreatePole([FromServices] IPoleService poleService,
        CreatePole createPole)
    {
        PoleResponse? pole = await poleService.CreatePole(createPole);
        ApiResult<PoleResponse> result = ApiResult<PoleResponse>.Succes(pole);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPole([FromServices] IPoleService poleService, int id)
    {
        PoleResponse? pole = await poleService.GetPole(id);
        ApiResult<PoleResponse> result = ApiResult<PoleResponse>.Succes(pole);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetPoles([FromServices] IPoleService poleService)
    {
        IEnumerable<PoleResponse> pole = await poleService.GetPole();
        ApiResult<IEnumerable<PoleResponse>> result = ApiResult<IEnumerable<PoleResponse>>.Succes(pole);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePole([FromServices] IPoleService poleService,
        CreatePole updatePole)
    {
        PoleResponse? pole = await poleService.UpdatePole(updatePole);
        ApiResult<PoleResponse> result = ApiResult<PoleResponse>.Succes(pole);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePole([FromServices] IPoleService poleService, int id)
    {
        PoleResponse? pole = await poleService.DeletePole(id);
        ApiResult<PoleResponse> result = ApiResult<PoleResponse>.Succes(pole);
        return Ok(result);
    }
}