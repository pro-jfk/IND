namespace App.Models;

public class CreateMessage
{
    //ID
    public int Id { get; set; }
    //Type of message
    public string Type { get; set; }
    //Time that message was send
    public DateTime DateSent { get; set; }
    //File Url
    public string FileURL { get; set; }
    
    //Customer ID
    public int CustomerId { get; set; }
}