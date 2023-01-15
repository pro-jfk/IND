using App.MappingProfile;
using App.Models;
using App.Services.impl;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Data;
using Data.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.NewServices;

public class MessageServiceTests
{
    [Fact]
    public async Task CreateMessage_AddsMessage()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "CreateMessage_AddsMessage")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var messageRepository = new MessageRepository(context);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MessageProfile>();
            });
            var mapper = new Mapper(config);
            var messageService = new MessageService(messageRepository, mapper);

            var createMessage = new CreateMessage
            {
                Id = 1,
                CustomerId = 1,
                FileURL = "fileshostingserver.com",
                Type = "invite"
                
            };
            // Act
            var createdMessage = await messageService.CreateMessage(createMessage);
            // Assert
            Assert.Equal(1, createdMessage.Id);
            Assert.Equal("invite", createdMessage.Type);
        }
    }

    [Fact]
    public async Task GetMessage_ReturnsCorrectMessage()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "GetMessage_ReturnsCorrectMessage")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var messageRepository = new MessageRepository(context);
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MessageProfile>(); });
            var mapper = new Mapper(config);
            var messageService = new MessageService(messageRepository, mapper);

            var message = new CreateMessage
            {
                Id = 1,
                CustomerId = 1,
                FileURL = "fileshostingserver.com",
                Type = "invite"
            };
            await messageService.CreateMessage(message);
            // Act
            var result = await messageService.GetMessage(1);
            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal(message.Type, result.Type);
            Assert.Equal(message.FileURL, result.FileURL);
        }
    }

    [Fact]
        public async Task GetMessagesForCustomer_ReturnsCorrectMessages()
        {
            // Arrange
            DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
                .UseInMemoryDatabase(databaseName: "GetMessagesForCustomer_ReturnsCorrectMessages")
                .Options;
            using (IndContext context = new IndContext(options))
            {
                var messageRepository = new MessageRepository(context);
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<MessageProfile>();
                });
                var mapper = new Mapper(config);
                var messageService = new MessageService(messageRepository, mapper);

                var message1 = new CreateMessage
                {
                    Id = 1,
                    CustomerId = 1,
                    FileURL = "fileshostingserver.com",
                    Type = "invite"
                };
                var message2 = new CreateMessage
                {
                    Id = 2,
                    CustomerId = 2,
                    FileURL = "fileshostingserver.com",
                    Type = "invite"
                    
                };
                var message3 = new CreateMessage
                {
                    Id = 3,
                    CustomerId = 2,
                    FileURL = "fileshostingserver.com",
                    Type = "invite"
                };
                await messageService.CreateMessage(message1);
                await messageService.CreateMessage(message2);
                await messageService.CreateMessage(message3);
                // Act
                var result = (await messageService.GetMessagesForCustomer(2)).ToList();
                // Assert
                Assert.Equal(2, result.Count());
                Assert.Equal(2, result.ElementAt(0).Id);
                Assert.Equal(3, result.ElementAt(1).Id);

            }
        }



        [Fact]
    public async Task UpdateMessageReceivedStatus_UpdatesStatus()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "UpdateMessageReceivedStatus_UpdatesStatus")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var messageRepository = new MessageRepository(context);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MessageProfile>();
            });
            var mapper = new Mapper(config);
            var messageService = new MessageService(messageRepository, mapper);
    
            var message = new CreateMessage
            {
                Id = 1,
                CustomerId = 1,
                StatusReceived = false,
                FileURL = "fileshostingserver.com",
                Type = "invite"
            };
            await messageService.CreateMessage(message);
            var dateReceived = DateTime.Now;
            var statusReceived = true;
            
            // Act
            await messageService.UpdateMessageReceived(1, 1, dateReceived, statusReceived);
            var result = await messageRepository.GetFirstASync(m => m.Id == 1);
            var test = await messageService.GetMessage(1);
            
            // Assert
            Assert.Equal(dateReceived, result.DateReceived);
            Assert.Equal(statusReceived, result.StatusReceived);
        }
    }
    
    [Fact]
    public async Task UpdateMessagePrintjob_UpdatesPrintJob()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "UpdateMessagePrintjob_UpdatesPrintJob")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var messageRepository = new MessageRepository(context);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MessageProfile>();
            });
            var mapper = new Mapper(config);
            var messageService = new MessageService(messageRepository, mapper);
    
            var message = new CreateMessage
            {
                Id = 1,
                CustomerId = 1,
                TimesPrinted = 0,
                StatusPrinted = false,
                FileURL = "fileshostingserver.com",
                Type = "message"
            };
            await messageService.CreateMessage(message);
            var statusPrinted = true;
            // Act
            await messageService.UpdateMessagePrintJob(1, 1, statusPrinted);

            var result = await messageRepository.GetFirstASync(m => m.Id == 1);
            // Assert
            Assert.Equal(1, result.TimesPrinted);
            Assert.Equal(statusPrinted, result.StatusPrinted);
        }
    }
    
    [Fact]
    public async Task DeleteMessage_DeletesCorrectly()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "DeleteMessage_DeletesCorrectly")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var messageRepository = new MessageRepository(context);
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MessageProfile>();
            });
            var mapper = new Mapper(config);
            var messageService = new MessageService(messageRepository, mapper);

            var message = new CreateMessage()
            {
                Id = 1,
                CustomerId = 1,
                FileURL = "fileshostingserver.com",
                Type = "invite"
            };
            await messageService.CreateMessage(message);
            // Act
            await messageService.DeleteMessage(1);
            // Assert
            
            await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await messageRepository.GetFirstASync(m => m.Id == 1));
        }
    }



}