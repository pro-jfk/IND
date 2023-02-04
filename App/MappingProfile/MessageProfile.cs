using App.Extensions;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;

namespace App.MappingProfile;

public class MessageProfile : Profile
{
    /// <summary>
    /// Creates a map for messages
    /// </summary>
    public MessageProfile()
    {
        CreateMap<CreateMessage, Message>();
        CreateMap<Message, MessageResponse>();
    }
}