using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class IndContext : DbContext
{
    /// <summary>
    /// A DbContext instance represents a session with the database and can be used to query and save instances of your entities
    /// </summary>
    /// <param name="options"></param>
   
    public IndContext (DbContextOptions<IndContext>options) : base(options){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EmergencyShelter> EmergencyShelters { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Pole> Poles { get; set; }
    public DbSet<CustomerMessage> CustomerMessages{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerMessage>()
            .HasKey(cm => new{cm.CustomerId,cm.MessageId}); //Creates Compound PKey for joined table Customer_Messages
        
        // modelBuilder.Entity<CustomerMessage>()
        //     .HasOne<Customer>(cm => cm.Customer)
        //     .WithMany(c => c.CustomerMessages)
        //     .HasForeignKey(cm => cm.CustomerId);
        //
        //
        // modelBuilder.Entity<CustomerMessage>()
        //     .HasOne<Message>(cm => cm.Message)
        //     .WithMany(c => c.CustomerMessages)
        //     .HasForeignKey(cm => cm.MessageId);
        
    }
}