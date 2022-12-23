using Core.Entities;

namespace Data.Repositories.Impl;

public class  MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(IndContext context) : base(context) {}
}