using App.Extensions;
using App.Models;
using App.Responses;
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
        CreateMap<CreateEmergencyShelter, EmergencyShelter>();
        CreateMap<EmergencyShelter, EmergencyShelterResponse>();
    }
}