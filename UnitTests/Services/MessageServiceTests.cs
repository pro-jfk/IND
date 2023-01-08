using System.Linq.Expressions;
using App.Models;
using App.Responses;
using App.Services;
using App.Services.impl;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using UnitTests.Mocks;
using UnitTests.Mocks.Repositories;
using UnitTests.Mocks.Services;


namespace UnitTests.Services;

public class MessageServiceTests 
{
    private readonly Mock<IMessageRepository> _mockMessageRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly MessageService _messageService;

    public MessageServiceTests()
    {
        _mockMessageRepository = new Mock<IMessageRepository>();
        var mockCustomerMessageService = new Mock<ICustomerMessageService>();
        _mockMapper = new Mock<IMapper>();
        _messageService = new MessageService(_mockMessageRepository.Object, _mockMapper.Object,
            mockCustomerMessageService.Object);
    }
    [Fact]
    public async Task GetMessage_Successful()
    {
        // Arrange
        var customerId = 1;
        var message = new Message
        {
            Id = 1,
            CustomerId = customerId,
            FileURL = "filehostserver.com",
            Type = "group-invite"
        };
        var messageResponse = new MessageResponse
        {
            Id = 1,
            FileURL = "filehostserver.com",
            Type = "group-invite"
        };
        _mockMessageRepository.Setup(x => x.GetFirstASync(m => m.CustomerId == customerId)).ReturnsAsync(message);
        _mockMapper.Setup(x => x.Map<MessageResponse>(message)).Returns(messageResponse);

        // Act
        var result = await _messageService.GetMessage(customerId);

        // Assert
        _mockMessageRepository.Verify(x => x.GetFirstASync(m => m.CustomerId == customerId), Times.Once);
        _mockMapper.Verify(x => x.Map<MessageResponse>(message), Times.Once);
        Assert.Equal(messageResponse, result);
        Assert.Equal(messageResponse.Type, message.Type);
    }
    
    // [Fact]
    // public async Task GetMessage_MessageDoesntExist_ReturnsException()
    // {
    //     //Arrange
    //     // var messageRepository = new MockMessageRepository().MockGetByIdInvalid();
    //     // var mockMapper = new Mock<IMapper>();
    //     // var mockCustomerMessageService = new Mock<ICustomerMessageService>();
    //     // var messageService = new MessageService(messageRepository.Object, mockMapper.Object, mockCustomerMessageService.Object);
    //     _mockMessageRepository.Setup(x => x.GetFirstASync(m => m.CustomerId == 1)).ReturnsAsync(message);
    //     _mockMapper.Setup(x => x.Map<MessageResponse>(message)).Returns(messageResponse);
    //     
    //     //Act
    //     var result =   messageService.GetMessage(1);
    //     
    //     //Assert
    //     await Assert.ThrowsAsync<ResourceNotFoundException>( async () => await result);
    //
    // }
    [Fact]
    public async Task GetMessage_Should_Fail()
    {
        // Arrange
        var customerId = 1;
        _mockMessageRepository.Setup(x => x.GetFirstASync(m => m.CustomerId == customerId)).ReturnsAsync((Message)null);

        // Act
        var result = await _messageService.GetMessage(customerId);

        // Assert
        _mockMessageRepository.Verify(x => x.GetFirstASync(m => m.CustomerId == customerId), Times.Once);
        _mockMapper.Verify(x => x.Map<MessageResponse>(It.IsAny<Message>()), Times.Never);
        Assert.Null(result);
    }
    [Fact]
    public async Task GetMessage_MappingFails()
    {
     
        // Arrange
        var customerId = 1;
        var message = new Message();
        _mockMessageRepository.Setup(x => x.GetFirstASync(m => m.CustomerId == customerId)).ReturnsAsync(message);
        _mockMapper.Setup(x => x.Map<MessageResponse>(message)).Throws<Exception>();

        // Act
        await Assert.ThrowsAsync<Exception>(() => _messageService.GetMessage(customerId));

        // Assert
        _mockMessageRepository.Verify(x => x.GetFirstASync(m => m.CustomerId == customerId), Times.Once);
        _mockMapper.Verify(x => x.Map<MessageResponse>(message), Times.Once);
    }


    [Fact]
    public void AddMessage()
    {
        
    }

    [Fact]
    public void PutMessage_PrintAndReceivedStatus()
    {
        
    }
  
}
//Arrange
//Act
//Assert