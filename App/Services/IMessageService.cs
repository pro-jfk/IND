using App.Models;
using App.Responses;

namespace App.Services;

public interface IMessageService
{
    Task<MessageResponse> GetMessage(int id);
}