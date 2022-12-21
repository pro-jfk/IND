using API.Controllers;
using App.Models;
using App.Responses;
using App.Services;
using Core.Entities;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests;

public class MessageControllerTests
{
    private readonly Mock<IMessageService> _mockMessageService;
    [Fact]
    
    public void GetMessage_ReturnsExpectedResult()
    {
        // Arrange
        var messageServiceMock = new Mock<IMessageService>();
        messageServiceMock.Setup(x => x.GetMessage(It.IsAny<int>()))
            .ReturnsAsync(new MessageResponse { Id = 1, Type = "test message" });

        var apiResultMock = new Mock<ApiResult<MessageResponse>>();
        apiResultMock.SetupGet(x => x.Succeeded).Returns(true);
        apiResultMock.SetupGet(x => x.Result).Returns(new MessageResponse  { Id = 1, Type = "test message" });
          
          var controller = new MessageController();

        // Act
        var result = controller.GetMessage(messageServiceMock.Object,1).Result;

        // Assert
        Assert.NotNull(result);
       // Assert.IsType(result, typeof(OkObjectResult));

        var objectResult = result as OkObjectResult;
        Assert.Equal(200, objectResult.StatusCode);

        var apiResult = objectResult.Value as ApiResult<MessageResponse>;
        Assert.NotNull(apiResult);
        Assert.True(apiResult.Succeeded);
        Assert.NotNull(apiResult.Result);
        Assert.Equal(1, apiResult.Result.Id);
        Assert.Equal("test message", apiResult.Result.Type);
        
        messageServiceMock.Verify(x => x.GetMessage(1), Times.Once());
        //apiResultMock.Verify(x => x.Succeeded(It.IsAny<MessageResponse>()), Times.Once());
    }

}