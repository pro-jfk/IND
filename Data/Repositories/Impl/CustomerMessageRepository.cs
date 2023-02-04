using Core.Entities;

namespace Data.Repositories.Impl;

public class CustomerMessageRepository : BaseRepository<CustomerMessage>, ICustomerMessageRepository
{
    public CustomerMessageRepository(IndContext context) : base(context)
    {
    }
}