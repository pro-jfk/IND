using System.Linq.Expressions;
using Core.Entities;

namespace Data.Repositories;

public interface IEmergencyShelterRepository
{
    Task<EmergencyShelter> GetFirstASync(Expression<Func<EmergencyShelter, bool>> predicate);
    Task<List<EmergencyShelter>> GetAllAsync();
    Task<EmergencyShelter> AddAsync(EmergencyShelter entity);
    Task<EmergencyShelter> UpdateAsync(EmergencyShelter entity);
    Task<EmergencyShelter> DeleteAsync(EmergencyShelter entity);
}