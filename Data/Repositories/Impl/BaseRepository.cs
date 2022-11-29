using System.Linq.Expressions;
using Core.Common;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly IndContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(IndContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
    
    /// <summary>
    /// Gets first Async
    /// </summary>
    /// <param name="predicate">id</param>
    /// <returns>Type: TEntity</returns>
    /// <exception cref="ResourceNotFoundException">not in db</exception>
    public async Task<TEntity> GetFirstASync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();
        if (entity == null)
            throw new ResourceNotFoundException(typeof(TEntity));

        return await DbSet.Where(predicate).FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Get all Async
    /// </summary>
    /// <param name="predicate">id</param>
    /// <returns>Type: TEntity</returns>
    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }
    
    /// <summary>
    /// Add Async
    /// </summary>
    /// <param name="entity">TEntity</param>
    /// <returns>Type: TEntity - addedEntity</returns>
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await Context.SaveChangesAsync();

        return addedEntity;
    }

    /// <summary>
    /// Update Async
    /// </summary>
    /// <param name="entity">TEntity</param>
    /// <returns>Type: TEntity - entity</returns>
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    /// <summary>
    /// Delete Async
    /// </summary>
    /// <param name="entity">TEntity</param>
    /// <returns>Type: TEntity - removedEntity</returns>
    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await Context.SaveChangesAsync();

        return removedEntity;
    }

}