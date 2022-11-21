using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core.Entities;

public class Customer : BaseEntity
{
    
   
    public int ID { get; set; }
    
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string Origin { get; set; }
    public DateTime DateAdded { get; set; }
  
    
    public List<Message>? Messages { get; set; }

    
    public int LocationID { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
   
}
