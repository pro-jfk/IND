using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;
using Data;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Services;
using App.Services.impl;
// using Xunit;

namespace UnitTests
{
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
        public async Task TestCreateMessage()
        {
            // Arrange
            CreateMessage createMessage = new CreateMessage
            {
                CustomerId = 1,
                FileURL = "Test message"
            };
            Message message = new Message
            {
                CustomerId = 1,
                FileURL = "Test message",
                DateSent = DateTime.Now
            };
            _mockMapper.Setup(m => m.Map<Message>(createMessage)).Returns(message);
            _mockMessageRepository.Setup(m => m.AddAsync(message)).ReturnsAsync(message);
            _mockMapper.Setup(m => m.Map<MessageResponse>(message)).Returns(new MessageResponse());

            // Act
            MessageResponse result = await _messageService.CreateMessage(createMessage);

            // Assert
            Assert.NotNull(result);
            _mockMapper.Verify(m => m.Map<Message>(createMessage), Times.Once());
            _mockMessageRepository.Verify(m => m.AddAsync(message), Times.Once());
            _mockMapper.Verify(m => m.Map<MessageResponse>(message), Times.Once());
        }

        [Fact]
        public async Task TestGetMessage()
        {
            // Arrange
            int customerId = 1;
            Message message = new Message
            {
                CustomerId = 1,
                FileURL = "Test message",
                DateSent = DateTime.Now
            };
            _mockMessageRepository.Setup(m => m.GetFirstASync(It.IsAny<Expression<Func<Message, bool>>>())).ReturnsAsync(message);
            _mockMapper.Setup(m => m.Map<MessageResponse>(message)).Returns(new MessageResponse());

            // Act
            MessageResponse result = await _messageService.GetMessage(customerId);

            // Assert
            Assert.NotNull(result);
        }
        
        
    }

}