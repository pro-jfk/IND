using App.Models;
using App.Services;

namespace UnitTests.Mocks.Services;

public class MockCustomerMessageService : Mock<ICustomerMessageService>
{
    public MockCustomerMessageService MockGetById(CreateMessage entity)
    {
        
        return this;
    }
}