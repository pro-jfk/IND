using App.Extensions;
using App.Models;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class PoleProfile : Profile
{
    public PoleProfile()
    {
        CreateMap<GetPole, Pole>();
    }
}