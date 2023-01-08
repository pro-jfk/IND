using Core.Entities;
using Core.Exceptions;
using Data;
using Data.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace UnitTests;

public class RepositoryTests
{
    private readonly IndContext _indContext;
    private readonly MessageRepository _repository;
    private readonly Message _testMessage;

    public RepositoryTests()
    {
        DbContextOptionsBuilder<IndContext> dbOptions =
            new DbContextOptionsBuilder<IndContext>().UseInMemoryDatabase(
                Guid.NewGuid()
                    .ToString());
        _indContext = new IndContext(dbOptions.Options);
        _repository = new MessageRepository(_indContext);
             
        _testMessage = new Message
        {
            Id = 1,
            FileURL = "filehostserver.com",
            Type = "invite",
            
        };
        _indContext.Messages.AddAsync(_testMessage);
        _indContext.SaveChanges();    
    }

    [Fact]
    public async void GetFirstAsync_WithValidInput_ReturnsCorrectMessage()
    {
        // Arrange

        // Act
        var result = await _repository.GetFirstASync(m => m.Id == _testMessage.Id);

        // Assert
        Assert.Equal(_testMessage, result);
    }
    
    [Fact]
    public async void GetFirstAsync_ThrowsResourceNotFoundException()
    {
        // Arrange
        

        // Act and Assert
        await Assert.ThrowsAsync<ResourceNotFoundException>(() => _repository.GetFirstASync(m => m.Id == 123456));
    }
    
    
    [Fact]
    public async void GetAllAsync_ReturnsAllMessages()
    {
        // Arrange
        var messages = new List<Message>
        {
            new Message {Id = 2, FileURL = "filehostserver.com",
                Type = "group-invite"},
            new Message{Id = 3, FileURL = "filehostserver.com",
                Type = "invite"},
            new Message{Id = 4, FileURL = "filehostserver.com",
                Type = "group-invite"}
        };
        _indContext.Messages.AddRange(messages);
        _indContext.SaveChanges();

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.Equal(messages.Count + 1, result.Count); // +1 for the initial test message in constructor
        Assert.Contains(_testMessage, result);
        Assert.All(messages, m => Assert.Contains(m, result));
    }
    
    [Fact]
    public async void UpdateAsync_UpdatesMessageInDatabase()
    {
        // Arrange
        _testMessage.Type = "Updated text";

        // Act
        var result = await _repository.UpdateAsync(_testMessage);

        // Assert
        var updatedMessage = await _indContext.Messages.FindAsync(_testMessage.Id);
        Assert.Equal(_testMessage.Type, updatedMessage.Type);
        Assert.Equal(_testMessage, result);
    }

}