using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data;

public class IndContext : DbContext
{
    
    public IndContext (DbContextOptions<IndContext>options) : base(options){}
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EmergencyShelter> EmergencyShelters { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Pole> Poles { get; set; }
    public DbSet<Customer_Message> Customer_Messages { get; set; }



}