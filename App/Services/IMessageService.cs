using App.Models;

namespace App.Services;

public interface IMessageService
{
    Task<MessageResponse> GetMessage(int id);
}