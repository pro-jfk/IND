using System.Linq.Expressions;
using Core.Common;

namespace Data.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public Task<TEntity> GetFirstASync(Expression<Func<TEntity, bool>> predicate);
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    public Task<TEntity> AddAsync(TEntity entity);
    public Task<TEntity> UpdateAsync(TEntity entity);
    public Task<TEntity> DeleteAsync(TEntity entity);
}