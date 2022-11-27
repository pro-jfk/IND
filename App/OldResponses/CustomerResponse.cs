namespace App.Models;

public class CustomerResponse
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Origin { get; set; }
    public int EmergencyShelterId { get; set; }
}