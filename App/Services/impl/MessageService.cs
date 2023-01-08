using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Services.impl;

public class MessageService : IMessageService
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;
    private readonly ICustomerMessageService _customerMessageService;
    // private readonly ICustomerRepository _customerRepository;

    public MessageService(IMessageRepository messageRepository, IMapper mapper, ICustomerMessageService customerMessageService)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
        _customerMessageService = customerMessageService;
    }
    
    
    public async Task<MessageResponse> CreateMessage(CreateMessage createMessage)
    {
        Message message = _mapper.Map<Message>(createMessage);
        message.DateSent = DateTime.Now;
        Message result = await _messageRepository.AddAsync(message);
        MessageResponse resultMapped =  _mapper.Map<MessageResponse>(result);
        CreateCustomerMessage createCustomerMessage = new CreateCustomerMessage
        {
            CustomerId = message.CustomerId,
            MessageId = message.Id
        };
        await _customerMessageService.CreateCustomerMessage(createCustomerMessage);
        return resultMapped;
    }

    public async Task<MessageResponse> GetMessage(int customerId)
    {
        Message result = await _messageRepository.GetFirstASync(m => m.CustomerId == customerId);
        return _mapper.Map<MessageResponse>(result);
    }

  

    public async Task<IEnumerable<MessageResponse>> GetMessages()
    {
        List<Message> result = await _messageRepository.GetAllAsync();
        return _mapper.Map<List<MessageResponse>>(result);
    }

    public async Task<MessageResponse> UpdateMessage(CreateMessage updateMessage)
    {
        Message message = _mapper.Map<Message>(updateMessage);
        Message result = await _messageRepository.UpdateAsync(message);
        return _mapper.Map<MessageResponse>(result);
    }

    public async Task<MessageResponse> DeleteMessage(int id)
    {
        Message message = await _messageRepository.GetFirstASync(m => m.CustomerId == id);
        Message result = await _messageRepository.DeleteAsync(message);
        return _mapper.Map<MessageResponse>(result);
    }
}