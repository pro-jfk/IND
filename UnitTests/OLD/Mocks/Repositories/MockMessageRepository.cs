using App.Models;
using App.Responses;
using Core.Entities;
using Core.Exceptions;
using Data.Repositories;
using Moq;
namespace UnitTests.Mocks.Repositories;

public class MockMessageRepository: Mock<IMessageRepository>
{
    public MockMessageRepository MockGetById(CreateMessage result)
    {
        Setup(x => x.GetFirstASync(c => c.CustomerId == result.CustomerId))
            .ReturnsAsync(new Message()
            {
                Id = result.Id,
                FileURL = result.FileURL,
                Type = result.Type,
                CustomerId = result.CustomerId
                
            });

        return this;
    }

    public MockMessageRepository MockGetByIdInvalid()
    {
        Setup(x => x.GetFirstASync(c => c.CustomerId == 1))
            .Throws(new ResourceNotFoundException(typeof(MessageResponse)));

        return this;
    }
}