using Core.Entities;

namespace Data.Repositories.Impl;

public class PoleRepository : BaseRepository<Pole>, IPoleRepository
{
    public PoleRepository(IndContext context) : base(context)
    {
    }
}