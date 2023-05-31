using App.Responses;
using App.Services.impl;
using AutoMapper;
using Core.Entities;
using Data.Repositories;

namespace UnitTests.OLD.Services;

public class MessageServiceTests
{
    private readonly Mock<IMessageRepository> _mockMessageRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly MessageService _messageService;

    public MessageServiceTests()
    {
        _mockMessageRepository = new Mock<IMessageRepository>();
        // var mockCustomerMessageService = new Mock<ICustomerMessageService>();
        _mockMapper = new Mock<IMapper>();
        _messageService = new MessageService(_mockMessageRepository.Object, _mockMapper.Object);
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
            FileURL = "fileshostingserver.com",
            Type = "group-invite"
        };
        var messageResponse = new MessageResponse
        {
            Id = 1,
            FileURL = "fileshostingserver.com",
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

    [Fact]
    public async Task GetMessagesForCustomer_Succeeds()
    {
        // Arrange
        var customerId = 1;
        var messages = new List<Message>
        {
            new Message { Id = 1, FileURL = "fileshostingserver.com", Type = "invite", CustomerId = customerId },
            new Message { Id = 2, FileURL = "fileshostingserver.com", Type = "invite", CustomerId = customerId }
        };
        var messageResponses = new List<MessageResponse> { new MessageResponse(), new MessageResponse() };
        _mockMessageRepository.Setup(x => x.GetAllAsyncByParameter(m => m.CustomerId == customerId))
            .ReturnsAsync(messages);
        _mockMapper.Setup(x => x.Map<List<MessageResponse>>(messages)).Returns(messageResponses);

        // Act
        var result = await _messageService.GetMessagesForCustomer(customerId);

        // Assert
        Assert.Equal(messageResponses, result);
        _mockMessageRepository.Verify(x => x.GetAllAsyncByParameter(m => m.CustomerId == customerId), Times.Once);
        _mockMapper.Verify(x => x.Map<List<MessageResponse>>(messages), Times.Once);
    }
    //
    // [Fact]
    // public async Task UpdateMessageReceivedStatus_UpdatesStatus()
    // {
    //     // Arrange
    //     DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
    //         .UseInMemoryDatabase(databaseName: "UpdateMessageReceivedStatus_UpdatesStatus")
    //         .Options;
    //     using (IndContext context = new IndContext(options))
    //     {
    //         var messageRepository = new MessageRepository(context);
    //         var config = new MapperConfiguration(cfg => {
    //             cfg.AddProfile<MessageProfile>();
    //         });
    //         var mapper = new Mapper(config);
    //         var messageService = new MessageService(messageRepository, mapper);
    //
    //         var message = new Message
    //         {
    //             Id = 1,
    //             CustomerId = 1,
    //             DateSent = DateTime.Now,
    //             StatusReceived = false,
    //         };
    //         await messageRepository.AddAsync(message);
    //         var dateReceived = DateTime.Now;
    //         var statusReceived = true;
    //         // Act
    //         var updatedMessage = await messageService.UpdateMessageReceived(1, 1, dateReceived, statusReceived);
    //         // Assert
    //         Assert.Equal(dateReceived, updatedMessage.d);
    //         Assert.Equal(statusReceived, updatedMessage.StatusReceived);
    //     }
    // }


    // [Fact]
    // public async Task GetMessage_MessageDoesntExist_ReturnsException()
    // {
    //     //Arrange
    //     var messageRepository = new MockMessageRepository().MockGetByIdInvalid();
    //     var mockMapper = new Mock<IMapper>();
    //     var mockCustomerMessageService = new Mock<ICustomerMessageService>();
    //     var messageService = new MessageService(messageRepository.Object, mockMapper.Object, mockCustomerMessageService.Object);
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
        var messageId = 1;
        var message = new Message();
        var exceptionMessage = "Mapping failed";
        _mockMessageRepository.Setup(x => x.GetFirstASync(m => m.Id == messageId)).ReturnsAsync(message);
        _mockMapper.Setup(x => x.Map<MessageResponse>(message)).Throws(new Exception(exceptionMessage));

        // Act  Assert
        var ex = await Assert.ThrowsAsync<Exception>(() => _messageService.GetMessage(messageId));
        Assert.Equal(exceptionMessage, ex.Message);
        _mockMessageRepository.Verify(x => x.GetFirstASync(m => m.Id == messageId), Times.Once);
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