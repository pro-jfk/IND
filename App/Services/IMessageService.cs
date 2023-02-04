using App.Models;
using App.Responses;
using Core.Entities;

namespace App.Services;

public interface IMessageService
{
    Task<MessageResponse> CreateMessage(CreateMessage createMessage);
    Task<MessageResponse> GetMessage(int id);
    Task<IEnumerable<MessageResponse>> GetMessagesForCustomer(int customerId);
    Task<IEnumerable<MessageResponse>> GetMessages();
    Task<MessageResponse> UpdateMessage(CreateMessage createMessage);

    Task<MessageResponse> UpdateMessagePrintJob(int customerId, int messageId, bool statusPrinted);
    Task<MessageResponse> UpdateMessageReceived(int customerId, int messageId, DateTime dateTime, bool statusReceived);
    Task<MessageResponse> DeleteMessage(int id);
}