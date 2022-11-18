using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Customer
{
    //TODO ADD FOREIGN KEYS AND CONFIG MYSGLQ DB AND MIGRATIONS
   
    public int ID { get; set; }
    
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string Origin { get; set; }
    public DateTime DateAdded { get; set; }
  
    
    public List<Message> Messages { get; set; }

    
    public string LocationID { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
   
}
