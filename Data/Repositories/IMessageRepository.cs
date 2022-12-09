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
    
    /// <summary>
    /// Get all Async
    /// </summary>
    /// <param name="predicate">id</param>
    /// <returns>Type: TEntity</returns>
    Task<List<Message>> GetAllAsync();
    
    /// <summary>
    /// Add Async
    /// </summary>
    /// <param name="entity">TEntity</param>
    /// <returns>Type: TEntity - addedEntity</returns>
    Task<Message> AddAsync(Message entity);
    
    /// <summary>
    /// Update Async
    /// </summary>
    /// <param name="entity">TEntity</param>
    /// <returns>Type: TEntity - entity</returns>
    Task<Message> UpdateAsync(Message entity);
    
    /// <summary>
    /// Delete Async
    /// </summary>
    /// <param name="entity">TEntity</param>
    /// <returns>Type: TEntity - removedEntity</returns>
    Task<Message> DeleteAsync(Message entity);
}