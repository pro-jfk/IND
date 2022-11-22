namespace App.Models;

public class CreateMessage
{
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime DateSent { get; set; }
    public string FileURL { get; set; }
    
    
    public int CustomerId { get; set; }
}