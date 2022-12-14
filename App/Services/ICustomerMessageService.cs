using App.Models;
using App.Responses;
using Core.Entities;

namespace App.Services;

public interface ICustomerMessageService
{
    Task<CustomerMessageResponse> CreateCustomerMessage(int customerId, int messageId);
    Task<CustomerMessageResponse> UpdateCustomerMessagePrint(int customerId, int messageId );
    Task<CustomerMessageResponse> UpdateCustomerMessageReceived(int customerId, int messageId);

   
}