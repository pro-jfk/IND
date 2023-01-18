using App.Models;
using App.Responses;
using AutoMapper;

namespace UnitTests.OLD.Mocks;

public class MockMapper: Mock<IMapper>
{
    public MockMapper GetById(CreateMessage createMessage)

    {
        var response = new MessageResponse();
        Setup(m => m.Map<MessageResponse>(createMessage));
        return this;
    }
}