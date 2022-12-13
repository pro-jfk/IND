using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace App.Services.impl;

public class PoleService : IPoleService
{
    private readonly IPoleRepository _poleRepository;
    private readonly IMapper _mapper;

    public PoleService(IPoleRepository poleRepository, IMapper mapper)
    {
        _poleRepository = poleRepository;
        _mapper = mapper;
    }
    
    public async Task<PoleResponse> CreatePole(CreatePole createPole)
    {
        Pole pole = _mapper.Map<Pole>(createPole);
        Pole result = await _poleRepository.AddAsync(pole);
        return _mapper.Map<PoleResponse>(result);
    }

    public async Task<PoleResponse> GetPole(int id)
    {
        Pole result = await _poleRepository.GetFirstASync(p => p.Id == id);
        return _mapper.Map<PoleResponse>(result);
    }

    public async Task<IEnumerable<PoleResponse>> GetPole()
    {
        List<Pole> result = await _poleRepository.GetAllAsync();
        return _mapper.Map<List<PoleResponse>>(result);
    }

    public async Task<PoleResponse> UpdatePole(CreatePole updatePole)
    {
        Pole pole = _mapper.Map<Pole>(updatePole);
        Pole result = await _poleRepository.UpdateAsync(pole);
        return _mapper.Map<PoleResponse>(result);
    }

    public async Task<PoleResponse> DeletePole(int id)
    {
        Pole pole = await _poleRepository.GetFirstASync(p => p.Id == id);
        Pole result = await _poleRepository.DeleteAsync(pole);
        return _mapper.Map<PoleResponse>(result);
    }
}