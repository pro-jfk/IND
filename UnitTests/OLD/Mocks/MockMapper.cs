using App.Models;
using App.Responses;
using AutoMapper;
using Core.Entities;

namespace UnitTests.Mocks;

public class MockMapper: Mock<IMapper>
{
    public MockMapper GetById(CreateMessage createMessage)

    {
        var response = new MessageResponse();
        Setup(m => m.Map<MessageResponse>(createMessage));
        return this;
    }
}