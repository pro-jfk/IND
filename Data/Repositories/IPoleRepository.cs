using System.Linq.Expressions;
using Core.Entities;

namespace Data.Repositories;

public interface IPoleRepository
{
    Task<Pole> GetFirstASync(Expression<Func<Pole, bool>> predicate);
    Task<List<Pole>> GetAllAsync();
    Task<Pole> AddAsync(Pole entity);
    Task<Pole> UpdateAsync(Pole entity);
    Task<Pole> DeleteAsync(Pole entity);
}