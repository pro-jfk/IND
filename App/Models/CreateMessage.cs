namespace App.Models;

public class CreateMessage
{
    public int Id { get; set; }
    //Type of message
    public string Type { get; set; }
    //File Url
    public string FileURL { get; set; }
    
    //Customer ID
    public int CustomerId { get; set; }
}