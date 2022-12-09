using App.Models;
using App.Responses;
using Core.Entities;

namespace App.Services;

public interface IMessageService
{
    Task<MessageResponse> CreateMessage(CreateMessage createMessage);
    Task<MessageResponse> GetMessage(int id);
    Task<IEnumerable<MessageResponse>> GetMessages();
    Task<MessageResponse> UpdateMessage(CreateMessage createMessage);
    Task<MessageResponse> DeleteMessage(int id);
}