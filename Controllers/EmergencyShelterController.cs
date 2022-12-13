using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Data.Repositories.Impl;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EmergencyShelterController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateEmergencyShelter(
        [FromServices] IEmergencyShelterService emergencyShelterService, CreateEmergencyShelter createEmergencyShelter)
    {
        EmergencyShelterResponse? emergencyShelter =
            await emergencyShelterService.CreateEmergencyShelter(createEmergencyShelter);
        ApiResult<EmergencyShelterResponse> result = ApiResult<EmergencyShelterResponse>.Succes(emergencyShelter);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmergencyShelter([FromServices] IEmergencyShelterService emergencyShelterService,
        int id)
    {
        EmergencyShelterResponse? emergencyShelter = await emergencyShelterService.GetEmergencyShelter(id);
        ApiResult<EmergencyShelterResponse> result = ApiResult<EmergencyShelterResponse>.Succes(emergencyShelter);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEmergencyShelters([FromServices] IEmergencyShelterService emergencyShelterService)
    {
        IEnumerable<EmergencyShelterResponse> emergencyShelter = await emergencyShelterService.GetEmergencyShelter();
        ApiResult<IEnumerable<EmergencyShelterResponse>> result = ApiResult<IEnumerable<EmergencyShelterResponse>>.Succes(emergencyShelter);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmergencyShelter([FromServices] IEmergencyShelterService emergencyShelterService, CreateEmergencyShelter updateEmergencyShelter)
    {
        EmergencyShelterResponse? emergencyShelter = await emergencyShelterService.UpdateEmergencyShelter(updateEmergencyShelter);
        ApiResult<EmergencyShelterResponse> result = ApiResult<EmergencyShelterResponse>.Succes(emergencyShelter);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteEmergencyShelter([FromServices] IEmergencyShelterService emergencyShelterService, int id)
    {
        EmergencyShelterResponse? emergencyShelter = await emergencyShelterService.DeleteEmergencyShelter(id);
        ApiResult<EmergencyShelterResponse> result = ApiResult<EmergencyShelterResponse>.Succes(emergencyShelter);
        return Ok(result);
    }
}