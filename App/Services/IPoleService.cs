using App.Models;
using App.Responses;

namespace App.Services;

public interface IPoleService
{
    Task<PoleResponse> CreatePole(PoleResponse createPole);
    Task<PoleResponse> GetPole(int id);
    Task<IEnumerable<PoleResponse>> GetPole();
    Task<PoleResponse> UpdatePole(CreatePole updatePole);
    Task<PoleResponse> DeletePole(int id);
}