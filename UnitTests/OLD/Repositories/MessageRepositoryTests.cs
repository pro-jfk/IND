using Core.Entities;
using Core.Exceptions;
using Data;
using Data.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.OLD.Repositories;

public class MessageRepositoryTests
{
    private readonly IndContext _indContext;
    
    //Each test run gets a new Db
    public MessageRepositoryTests()
    {
        DbContextOptionsBuilder<IndContext> dbOptions = new DbContextOptionsBuilder<IndContext>().UseInMemoryDatabase(
            Guid.NewGuid()
                .ToString());
        _indContext = new IndContext(dbOptions.Options);
    }
   
     
     [Fact]
     public async Task GetMessageByIdAsync_Returns_Message(){
        //Arrange 
        var messageEntity = new Message()
        {
            Id = 1,
            Type = "invite",
            FileURL = "google",
            CustomerId = 1234567890,
            DateSent = DateTime.Now
            
        };
        var messageRepository= new MessageRepository(_indContext);
        await messageRepository.AddAsync(messageEntity);

        //Act
        var message = await messageRepository.GetFirstASync(m => m.Id == 1);

         //Assert
         Assert.Equal(message.Id, messageEntity.Id);
         Assert.IsType<Message>(message);

     }

     [Fact]

     public async Task GetMessageById_ReturnsError()
     {
         var messageRepository= new MessageRepository(_indContext);
         

         //Execute method of SUT(ProductsRepository
         var result =  messageRepository.GetFirstASync(m => m.Id == 2);

         //Assert
        await Assert.ThrowsAnyAsync<ResourceNotFoundException>(async () => await result);
     }
     
     
}