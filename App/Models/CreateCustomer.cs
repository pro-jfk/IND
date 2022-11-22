namespace App.Models;

public class CreateCustomer
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string FirstName { get; set; }
    public string Origin { get; set; }
    public string LanguagesSpoken { get; set; }
    public string PhoneNumber { get; set; }
    public int LocationID { get; set; }
}