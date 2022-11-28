using App.Models;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class EmergencyShelterProfile : Profile
{
    /// <summary>
    /// Creates a map for Emergency shelter
    /// </summary>
    public EmergencyShelterProfile()
    {
        CreateMap<GetEmergencyShelter, EmergencyShelter>();
    }
}