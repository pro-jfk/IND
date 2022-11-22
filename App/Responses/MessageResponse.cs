namespace App.Models;

public class MessageResponse
{
    public string Type { get; set; }
    public DateTime DateSent { get; set; }
    public string FileURL { get; set; }
    public int CustomerId { get; set; }
    
}