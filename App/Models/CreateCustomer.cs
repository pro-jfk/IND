using Core.Entities;

namespace App.Models;

public class CreateCustomer
{
    //Vnumber
    public int Id { get; set; }
    
    //Last name
    public string LastName { get; set; }
    //First Name
    public string FirstName { get; set; }
    //Country of Origin
    public string Origin { get; set; }
    //Languages spoken by Customer
    public string LanguagesSpoken { get; set; }
    
    public string FingerPrint { get; set; }
    
    public int FingerprintIdArduino { get; set; }
    //PhoneNumber
    public string PhoneNumber { get; set; }
    //EmergencyShelterID
    public int EmergencyShelterId { get; set; }
    
    //For Prototype purposes
    public int FingerprintIdArduino { get; set; }
}