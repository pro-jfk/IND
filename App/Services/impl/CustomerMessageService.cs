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
    public async Task<CustomerMessageResponse> CreateCustomerMessage(CreateCustomerMessage createCustomerMessage)
    {
        CustomerMessage customerMessage = _mapper.Map<CustomerMessage>(createCustomerMessage);
        customerMessage.CustomerId = 1;
        PrintMessage();
        _customerMessageRepository.UpdateAsync();
        return NotImplementedException;
        
        }

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