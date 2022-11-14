using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string Origin { get; set; }
    public DateTime DateAdded { get; set; }
    public string LocationID { get; set; }
    
    
    [ForeignKey("EmergencyShelter")]
    public string Location { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
   
}
