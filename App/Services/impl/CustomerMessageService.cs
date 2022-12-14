using System.Net.Http.Headers;
using System.Text;
using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace App.Services.impl;

public class CustomerMessageService : ICustomerMessageService
{
    private readonly ICustomerMessageRepository _customerMessageRepository;
    private readonly IMapper _mapper;
    
    //PrintNode API token and API
    private  HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://api.printnode.com/printjobs")
    };
    
    private readonly string ApiToken = "cX6VaQJ61hZDim6R-0dMLGdfvMwN1tiQ0Wuv2MilRgs";
    

    public CustomerMessageService(ICustomerMessageRepository customerMessageRepository, IMapper mapper)
    {
        _customerMessageRepository = customerMessageRepository;
        _mapper = mapper;
    }
    //Create CustomerMessage
    public async Task<CustomerMessageResponse> CreateCustomerMessage(int customerId, int messageId)
    {
        CustomerMessage customerMessage = new CustomerMessage();
        customerMessage.CustomerId = customerId;
        customerMessage.MessageId = messageId;


        return _mapper.Map<CustomerMessageResponse>(customerMessage);
    }
    //Update CustomerMessage Print Details
    public async Task<CustomerMessageResponse> UpdateCustomerMessagePrint(int customerId, int messageId)
    {
        CustomerMessage customerMessage = await _customerMessageRepository.GetFirstASync(cm => cm.CustomerId == customerId && cm.MessageId == messageId );        customerMessage.TimesPrinted += 1;

        if (customerMessage.TimesPrinted >= 1)
        {
            customerMessage.StatusPrinted = true;
        }
        CustomerMessage result = await _customerMessageRepository.UpdateAsync(customerMessage);
        return _mapper.Map<CustomerMessageResponse>(result);
    }
    
    //Update CustomerMessage Received Details

    public async Task<CustomerMessageResponse> UpdateCustomerMessageReceived(int customerId, int messageId)
    {
        CustomerMessage customerMessage = await _customerMessageRepository.GetFirstASync(cm => cm.CustomerId == customerId && cm.MessageId == messageId );
        //customerMessage = _mapper.Map<CustomerMessage>();
        customerMessage.StatusReceived = true;
        customerMessage.DateReceived = DateTime.Now;
        CustomerMessage result = await _customerMessageRepository.UpdateAsync(customerMessage);
        return _mapper.Map<CustomerMessageResponse>(result);
    }

    //API-call to PrintNode
    //Docs: https://www.printnode.com/en/docs/api/curl
    public async void PrintMessage()
    {
        var bytes = Encoding.UTF8.GetBytes(ApiToken);
        string encodeUri = Convert.ToBase64String(bytes);
        
        sharedClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Basic", encodeUri);

        var bytes_test = Encoding.UTF8.GetBytes("hello");
        string testContent = Convert.ToBase64String(bytes_test);
        
        var values = new Dictionary<string, string>
        {
            { "printerId", "71908910" },
            { "title", "example" },
            { "contentType", "raw_base64" },
            {"content", testContent },
            //Printer configurations
            {"supports_custom_paper_size", "true"},
            {"fit_to_page", "true"}
        };
        var content = new FormUrlEncodedContent(values);
        using var response = await sharedClient.PostAsync(sharedClient.BaseAddress, content);
        var responseString = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseString);
        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"{jsonResponse}\n");
    }
    public CustomerMessageResponse NotImplementedException { get; }
    
}