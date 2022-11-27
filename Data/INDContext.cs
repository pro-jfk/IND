using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class IndContext : DbContext
{
    //TODO run removed middlename migration
    public IndContext (DbContextOptions<IndContext>options) : base(options){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EmergencyShelter> EmergencyShelters { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Pole> Poles { get; set; }
    public DbSet<Customer_Message> Customer_Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer_Message>()
            .HasKey(t => new{t.CustomerId,t.MessageId}); //Creates Compound PKey for joined table Customer_Messages
            
        
    }
}