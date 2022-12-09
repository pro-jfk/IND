using System.Net;
using System.Text;
using System.Text.Json;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerMessageController : ApiController
{

    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://api.printnode.com"),

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

    //POST 
    // [HttpPost]
    // public async Task<string> PostMessage(HttpClient httpClient, string postData)
    // {
    //     
    //     using StringContent jsonContent = new(
    //         JsonSerializer.Serialize(new
    //         {
    //             userId = 77,
    //             id = 1,
    //             title = "write code sample",
    //             completed = false
    //         }),
    //         Encoding.UTF8,
    //         "application/json");
    //
    //     using HttpResponseMessage response = await httpClient.PostAsync(
    //         sharedClient.BaseAddress,
    //         jsonContent);
    //
    //     response.EnsureSuccessStatusCode();
    //
    //     var jsonResponse = await response.Content.ReadAsStringAsync();
    //     Console.WriteLine($"{jsonResponse}\n");
    //     return "foo";
    //     }
    //
    // }

    [HttpPost]
    public IActionResult Create(string pizza)
    {

        return CreatedAtAction(nameof(Create), new { id = pizza }, pizza);
    }

}

