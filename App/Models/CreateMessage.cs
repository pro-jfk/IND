namespace App.Models;

public class CreateMessage
{
    //Type of message
    public string Type { get; set; }
    //File Url
    public string FileURL { get; set; }
    
    //Customer ID
    public int CustomerId { get; set; }
}