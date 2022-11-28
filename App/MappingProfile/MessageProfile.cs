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
        CreateMap<GetMessage, Message>()
            .IgnoreDestination(m => m.DateSent);

        CreateMap<Message, MessageResponse>();
    }
}