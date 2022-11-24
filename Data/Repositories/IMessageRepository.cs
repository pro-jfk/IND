using System.Linq.Expressions;
using Core.Entities;

namespace Data.Repositories;

public interface IMessageRepository
{
    Task<Message> GetFirstASync(Expression<Func<Message, bool>> predicate);
    Task<List<Message>> GetAllAsync(Expression<Func<Message, bool>> predicate);
    Task<Message> AddAsync(Message entity);
    Task<Message> UpdateAsync(Message entity);
    Task<Message> DeleteAsync(Message entity);
}