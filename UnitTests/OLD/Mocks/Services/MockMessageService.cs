using App.Responses;
using App.Services;
using Core.Entities;
using Core.Exceptions;

namespace UnitTests.Mocks.Services;

public class MockMessageService : Mock<IMessageService>
{
    public MockMessageService MockGetById(Message result)
    {
        Setup(x => x.GetMessage(result.Id))
            .ReturnsAsync(new MessageResponse()
            {
                Id = result.Id,
                FileURL = result.FileURL,
                Type = result.Type
            });

        return this;
    }


}