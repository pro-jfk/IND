namespace App.Models;

public class CustomerResponse
{
    //Vnumber
    public int Id { get; set; }
    //LastName
    public string LastName { get; set; }
    //FirstName
    public string FirstName { get; set; }
    //Country of Origin
    public string Origin { get; set; }
    //Emergency Shelter ID
    public int EmergencyShelterId { get; set; }
}