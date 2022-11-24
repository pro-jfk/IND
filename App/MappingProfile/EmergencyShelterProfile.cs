using App.Models;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class EmergencyShelterProfile : Profile
{
    public EmergencyShelterProfile()
    {
        CreateMap<GetEmergencyShelter, EmergencyShelter>();
    }
}