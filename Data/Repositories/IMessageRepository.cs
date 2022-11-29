using System.Linq.Expressions;
using Core.Entities;

namespace Data.Repositories;

public interface IMessageRepository
{
    /// <summary>
    /// Gets first Async
    /// </summary>
    /// <param name="predicate">id</param>
    /// <returns>Type: TEntity</returns>
    /// <exception cref="ResourceNotFoundException">not in db</exception>
    /// TODO Add all the summaries from BaseRepository in here aswell
    Task<Message> GetFirstASync(Expression<Func<Message, bool>> predicate);
    Task<List<Message>> GetAllAsync(Expression<Func<Message, bool>> predicate);
    Task<Message> AddAsync(Message entity);
    Task<Message> UpdateAsync(Message entity);
    Task<Message> DeleteAsync(Message entity);
}