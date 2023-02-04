using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace App.Services.impl;

public class EmergencyShelterService : IEmergencyShelterService
{
    private readonly IEmergencyShelterRepository _emergencyShelterRepository;
    private readonly IMapper _mapper;

    public EmergencyShelterService(IEmergencyShelterRepository emergencyShelterRepository, IMapper mapper)
    {
        _emergencyShelterRepository = emergencyShelterRepository;
        _mapper = mapper;
    }

    public async Task<EmergencyShelterResponse> CreateEmergencyShelter(CreateEmergencyShelter createEmergencyShelter)
    {
        EmergencyShelter emergencyShelter = _mapper.Map<EmergencyShelter>(createEmergencyShelter);
        EmergencyShelter result = await _emergencyShelterRepository.AddAsync(emergencyShelter);
        return _mapper.Map<EmergencyShelterResponse>(result);
    }

    public async Task<EmergencyShelterResponse> GetEmergencyShelter(int id)
    {
        EmergencyShelter result = await _emergencyShelterRepository.GetFirstASync(e => e.Id == id);
        return _mapper.Map<EmergencyShelterResponse>(result);
    }

    public async Task<IEnumerable<EmergencyShelterResponse>> GetEmergencyShelter()
    {
        List<EmergencyShelter> result = await _emergencyShelterRepository.GetAllAsync();
        return _mapper.Map<List<EmergencyShelterResponse>>(result);
    }

    public async Task<EmergencyShelterResponse> UpdateEmergencyShelter(CreateEmergencyShelter updateEmergencyShelter)
    {
        EmergencyShelter emergencyShelter = _mapper.Map<EmergencyShelter>(updateEmergencyShelter);
        EmergencyShelter result = await _emergencyShelterRepository.UpdateAsync(emergencyShelter);
        return _mapper.Map<EmergencyShelterResponse>(result);
    }

    public async Task<EmergencyShelterResponse> DeleteEmergencyShelter(int id)
    {
        EmergencyShelter emergencyShelter = await _emergencyShelterRepository.GetFirstASync(e => e.Id == id);
        EmergencyShelter result = await _emergencyShelterRepository.DeleteAsync(emergencyShelter);
        return _mapper.Map<EmergencyShelterResponse>(result);
    }
}