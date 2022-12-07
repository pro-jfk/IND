using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class IndContext : DbContext
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to query and save instances of your entities
    /// </summary>
    /// <param name="options"></param>
    //TODO Run migrations for TimesPrinted field in Customer_Message
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