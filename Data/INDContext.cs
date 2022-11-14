using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class IndContext : DbContext
{
    // public Context (DbContextOptions<Context>options) : base(options){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EmergencyShelter> EmergencyShelters { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Pole> Poles { get; set; }

}