using Core.Entities.Mail;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Mail> Mails { get; set; }
    public DbSet<MailStatus> MailStatuses { get; set; }
}