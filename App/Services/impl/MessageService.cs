using System.Net.Http.Headers;
using System.Text;
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
    // private readonly ICustomerMessageService _customerMessageService;
    // private readonly ICustomerRepository _customerRepository;
    
     //PrintNode API token and API
     private readonly HttpClient _sharedClient = new()
     {
         BaseAddress = new Uri("https://api.printnode.com/printjobs")
     };
     private readonly string _apiToken = "GsShY5qYDo9GuQZf0ydEt7Mn4kvZhrHQ4d1d3gVeyDY";


    public MessageService(IMessageRepository messageRepository, IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
        // _customerMessageService = customerMessageService;
    }
    
    
    public async Task<MessageResponse> CreateMessage(CreateMessage createMessage)
    {
        Message message = _mapper.Map<Message>(createMessage);
        message.DateSent = DateTime.Now;
        Message result = await _messageRepository.AddAsync(message);
        MessageResponse resultMapped =  _mapper.Map<MessageResponse>(result);
        // CreateCustomerMessage createCustomerMessage = new CreateCustomerMessage
        // {
        //     CustomerId = message.CustomerId,
        //     MessageId = message.Id
        // };
        // await _customerMessageService.CreateCustomerMessage(createCustomerMessage);
        return resultMapped;
    }

    public async Task<MessageResponse> GetMessage(int messageId)
    {
        Message result = await _messageRepository.GetFirstASync(m => m.Id == messageId);
        return _mapper.Map<MessageResponse>(result);
    }

    public async Task<IEnumerable<MessageResponse>> GetMessagesForCustomer(int customerId)
    {
        List<Message> result = await _messageRepository.GetAllAsyncByParameter(c => c.CustomerId==customerId);
        
        return _mapper.Map<List<MessageResponse>>(result);
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
    
     //Update Message Received Details
     public async Task<MessageResponse> UpdateMessageReceived(int customerId, int messageId, DateTime dateReceived, bool statusReceived)
     {
         Message message = await _messageRepository.GetFirstASync(m => m.CustomerId == customerId && m.Id == messageId );
         message.DateReceived = dateReceived;
         message.StatusReceived = statusReceived;
         Message result = await _messageRepository.UpdateAsync(message);
         return _mapper.Map<MessageResponse>(result);
     }
    
    //Update CustomerMessage Print Details
     public async Task<MessageResponse> UpdateMessagePrintJob(int customerId, int messageId, bool statusPrinted)
     {
         Message message = await _messageRepository.GetFirstASync(m => m.CustomerId == customerId && m.Id == messageId );
         message.TimesPrinted += 1;
         message.StatusPrinted = statusPrinted;
         // while (customerMessage.TimesPrinted >= 1)
         // {
         //     customerMessage.StatusPrinted = true;
         // }
         Message result = await _messageRepository.UpdateAsync(message);
         return _mapper.Map<MessageResponse>(result);
     }
     
    public async Task<MessageResponse> DeleteMessage(int id)
    {
        Message message = await _messageRepository.GetFirstASync(m => m.CustomerId == id);
        Message result = await _messageRepository.DeleteAsync(message);
        return _mapper.Map<MessageResponse>(result);
    }
    
    //API-call to PrintNode
    //Docs: https://www.printnode.com/en/docs/api/curl
    public async void PrintMessage()
     {
         var apiTokenBytes = Encoding.UTF8.GetBytes(_apiToken);
         string encodedApiTokenBytes = Convert.ToBase64String(apiTokenBytes);
         
         _sharedClient.DefaultRequestHeaders.Authorization =
             new AuthenticationHeaderValue("Basic", encodedApiTokenBytes);
         
         var values = new Dictionary<string, string>
         {
             { "printerId", "71908910" },
             { "title", "example" },
             { "contentType", "pdf_uri" },
             {"content", "https://cdn.discordapp.com/attachments/1023870407155134468/1068479233233539132/Voorbeeld_bon.pdf" },
             //Printer configurations
             {"supports_custom_paper_size", "true"},
             {"fit_to_page", "true"}
         };
         var content = new FormUrlEncodedContent(values);
         using var response = await _sharedClient.PostAsync(_sharedClient.BaseAddress, content);
         var responseString = await response.Content.ReadAsStringAsync();

         Console.WriteLine(responseString);
         var jsonResponse = await response.Content.ReadAsStringAsync();
         Console.WriteLine($"{jsonResponse}\n");
     }

}