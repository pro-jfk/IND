using Core.Entities;

namespace Data.Repositories;
using System.Linq.Expressions;
using Core.Common;

public interface ICustomerMessageRepository
{
    public Task<CustomerMessage> GetFirstASync(Expression<Func<CustomerMessage, bool>> predicate);
    public Task<List<CustomerMessage>> GetAllAsync();
    public Task<CustomerMessage> AddAsync(CustomerMessage customerMessage);
    public Task<CustomerMessage> UpdateAsync(CustomerMessage customerMessage);
    public Task<CustomerMessage> DeleteAsync(CustomerMessage customerMessage);

}