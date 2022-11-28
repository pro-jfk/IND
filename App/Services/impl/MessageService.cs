using App.Models;
using App.Responses;
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
    /// <summary>
    /// Get message from the messageRepository
    /// </summary>
    /// <param name="id">int</param>
    /// <returns>Type: Message from db where id = id</returns>
    public async Task<MessageResponse> GetMessage(int id)
    {
        Message result = await _messageRepository.GetFirstASync(m => m.CustomerId == id);
        return _mapper.Map<MessageResponse>(result);
    }
}