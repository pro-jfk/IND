using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using Core.Common;

namespace Core.Entities;

public class Customer : BaseEntity
{
    
    //Vnumber
    public int Id { get; set; }
    
    //Last Name
    public string LastName { get; set; }
    //First Name
    public string FirstName { get; set; }
    //Country of Origin
    public string Origin { get; set; }
    //Languages spoken by Customer
    public string LanguagesSpoken { get; set; }
    
    public byte [] HashedFingerPrint { get; set; }

    public byte [] Salt { get;  set; }
    //Phone number of Customer
    public string PhoneNumber { get; set; }
    //Time Customer was created
    public DateTime DateAdded { get; set; }
  
    //Messages for Customer
    public List<Message>? Messages { get; set; }

    //Emergency Shelter
    public int EmergencyShelterId { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
    
    public int FingerprintIdArduino { get; set; }
    public ICollection<CustomerMessage> CustomerMessages { get; set; }

}
