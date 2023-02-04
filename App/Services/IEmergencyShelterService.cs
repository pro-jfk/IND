using App.Models;
using App.Responses;

namespace App.Services;

public interface IEmergencyShelterService
{
    Task<EmergencyShelterResponse> CreateEmergencyShelter(CreateEmergencyShelter createEmergencyShelter);
    Task<EmergencyShelterResponse> GetEmergencyShelter(int id);
    Task<IEnumerable<EmergencyShelterResponse>> GetEmergencyShelter();
    Task<EmergencyShelterResponse> UpdateEmergencyShelter(CreateEmergencyShelter updateEmergencyShelter);
    Task<EmergencyShelterResponse> DeleteEmergencyShelter(int id);
}