using System.Linq.Expressions;
using Core.Entities;
using Core.Exceptions;

namespace Data.Repositories;

public interface IMessageRepository
{
    /// <summary>
    /// Gets first Async
    /// </summary>
    /// <param name="predicate">id</param>
    /// <returns>Type: TEntity</returns>
    /// <exception cref="ResourceNotFoundException">Not in Db</exception>
    /// TODO Add all the summaries from BaseRepository in here aswell
    Task<Message> GetFirstASync(Expression<Func<Message, bool>> predicate);

    /// <summary>
    /// Get all Async
    /// </summary>
    /// <returns>Type: <list type="TEntity"></list></returns>
    Task<List<Message>> GetAllAsync();

    /// <summary>
    /// Get all Async with a Parameter
    /// </summary>
    /// <param name="predicate">id</param>
    /// <returns>Type: <list type="TEntity"></list></returns>
    public Task<List<Message>> GetAllAsyncByParameter(Expression<Func<Message, bool>> predicate);

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