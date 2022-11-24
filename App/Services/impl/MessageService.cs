using App.Models;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace App.Services.impl;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public async Task<MessageResponse> GetMessage(int id)
    {
        Message result = await _messageRepository.GetFirstASync(m => m.CustomerId == id);
        return _mapper.Map<MessageResponse>(result);
    }
}