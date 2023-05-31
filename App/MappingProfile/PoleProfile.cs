using App.Extensions;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class PoleProfile : Profile
{
    public PoleProfile()
    {
        CreateMap<CreatePole, Pole>();
        CreateMap<Pole, PoleResponse>();
    }
}