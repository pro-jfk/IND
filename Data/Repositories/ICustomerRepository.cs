using System.Linq.Expressions;
using Core.Entities;

namespace Data.Repositories;

public interface ICustomerRepository
{
    Task<Customer> GetFirstASync(Expression<Func<Customer, bool>> predicate);
    Task<List<Customer>> GetAllAsync();
    Task<Customer> AddAsync(Customer entity);
    Task<Customer> UpdateAsync(Customer entity);
    Task<Customer> DeleteAsync(Customer entity);
}