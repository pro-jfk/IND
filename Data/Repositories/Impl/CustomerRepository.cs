using Core.Entities;

namespace Data.Repositories.Impl;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(IndContext context) : base(context) {}
}