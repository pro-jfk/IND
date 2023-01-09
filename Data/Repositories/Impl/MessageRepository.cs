using System.Linq.Expressions;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Impl;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(IndContext context) : base(context) {}

    public async Task<List<Message>> GetAllAsyncByParameter(Expression<Func<Message, bool>> predicate)
    {
        var entity = await DbSet.Where(predicate).ToListAsync();
        
        if (entity == null)
            throw new ResourceNotFoundException(typeof(Message));

        return entity;
    }

}