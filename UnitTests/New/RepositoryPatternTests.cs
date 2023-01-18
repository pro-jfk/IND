using Core.Entities;
using Core.Exceptions;
using Data;
using Data.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.New;


public class RepositoryPatternTests
{
    [Fact]
    public async Task GetFirstASync_ReturnsCorrectEntity()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "GetFirstASync_ReturnsCorrectEntity")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var repository = new BaseRepository<Message>(context);

            var entity1 = new Message { Id = 1, FileURL = "fileshostingserver.com", Type = "invite"};
            var entity2 = new Message { Id = 2, FileURL = "fileshostingserver.com", Type = "invite" };
            await repository.AddAsync(entity1);
            await repository.AddAsync(entity2);

            // Act
            var result = await repository.GetFirstASync(e => e.Id == 1);

            // Assert
            Assert.Equal(1, result.Id);
        }
    }
    
    [Fact]
    public async Task AddAsync_AddsCorrectly()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "AddAsync_AddsCorrectly")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var repository = new BaseRepository<Message>(context);
            var entity = new Message { Id = 1, FileURL = "fileshostingserver.com", Type = "invite" };

            // Act
            await repository.AddAsync(entity);
            var addedEntity = await context.Messages.FirstOrDefaultAsync(e => e.Id == 1);

            // Assert
            Assert.Equal(1, addedEntity.Id);
        }
    }
    
    
    [Fact]
    public async Task GetFirstASync_ThrowsExceptionWhenEntityNotFound()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "GetFirstASync_ThrowsExceptionWhenEntityNotFound")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var repository = new BaseRepository<Message>(context);

            // Act and Assert
            await Assert.ThrowsAsync<ResourceNotFoundException>(() => repository.GetFirstASync(e => e.Id == 1));
        }
    }

    [Fact]
    public async Task DeleteAsync_DeletesCorrectly()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "DeleteAsync_DeletesCorrectly")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var repository = new BaseRepository<Message>(context);
            var entity = new Message { Id = 1, FileURL = "fileshostingserver.com", Type = "invite" };
            await repository.AddAsync(entity);

            // Act
            var result = await repository.DeleteAsync(entity);

            // Assert
            var deletedEntity = await context.Messages.FirstOrDefaultAsync(e => e.Id == 1);
            Assert.Null(deletedEntity);
        }
    }
    
    
    [Fact]
    public async Task GetAllAsyncByParameter_ReturnsCorrectEntities()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "GetAllAsyncByParameter_ReturnsCorrectEntities")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var repository = new MessageRepository(context);
        
            var message1 = new Message { Id = 1, CustomerId = 1, FileURL = "fileshostingserver.com", Type = "invite" };
            var message2 = new Message { Id = 2, CustomerId = 1, FileURL = "fileshostingserver.com", Type = "invite" };
            var message3 = new Message { Id = 3, CustomerId = 2, FileURL = "fileshostingserver.com", Type = "invite" };
            await repository.AddAsync(message1);
            await repository.AddAsync(message2);
            await repository.AddAsync(message3);

            // Act
            var result = await repository.GetAllAsyncByParameter(m => m.CustomerId == 1);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(1, result.First().Id);
        }
    }
}