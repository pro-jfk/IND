using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Customer
{
    
   
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string Origin { get; set; }
    public string LanguagesSpoken { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateAdded { get; set; }
  
    
    public List<Message> Messages { get; set; }

    
    public int EmergencyShelterId { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
}
