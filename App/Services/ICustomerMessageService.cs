using App.Models;
using App.Responses;
using Core.Entities;

namespace App.Services;

public interface ICustomerMessageService
{
    public Task<CustomerMessageResponse> CreateCustomerMessage(CreateCustomerMessage createCustomerMessage);
   
}