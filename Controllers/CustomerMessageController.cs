using App.Models;
using App.Responses;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerMessageController : ApiController
{

    //PrintNode API token and API
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://api.printnode.com/printjobs"),

    };

    private readonly string ApiToken = "cX6VaQJ61hZDim6R-0dMLGdfvMwN1tiQ0Wuv2MilRgs";



    //TODO GET printjob details
    //TODO Post request to call PRINTJOB
    //TODO Validate POST request to call Printjob
    [HttpGet]
    public async Task<string[]> GetMessage()
    {
        string[] test = { "hello", " world", "!" };
        return test;
    }

    
    [HttpPost]  
    public async Task<IActionResult> CreateCustomerMessage([FromServices] ICustomerMessageService customerMessageService,
        CreateCustomerMessage createCustomerMessage)
    {
        CustomerMessageResponse? customerMessage = await customerMessageService.CreateCustomerMessage(createCustomerMessage);
        ApiResult<CustomerMessageResponse> result = ApiResult<CustomerMessageResponse>.Succes(customerMessage);
        return Ok(result);
    }
    
    

}

