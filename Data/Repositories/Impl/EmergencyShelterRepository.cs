using Core.Entities;

namespace Data.Repositories.Impl;

public class EmergencyShelterRepository : BaseRepository<EmergencyShelter>, IEmergencyShelterRepository
{
    public EmergencyShelterRepository(IndContext context) : base(context)
    {
    }
}