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

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Customer>().HasData(
    //         new Customer()
    //         {
    //             //CustomerId = "v_number",
    //             LastName = "last_name",
    //             MiddleName = "middle_name",
    //             FirstName = "first_name",
    //             Origin = "origin",
    //             DateAdded = Convert.ToDateTime("date_of_birth")
    //             
    //              
    //         }
    //     );
    //}
}