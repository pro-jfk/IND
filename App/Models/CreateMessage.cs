namespace App.Models;

public class CreateMessage
{
    public int Id { get; set; }
    //Type of message
    public string Type { get; set; }
    //File Url
    public string FileURL { get; set; }
         
    //If message is received by Customer
    public bool StatusReceived { get; set; }
    //If message is printed by Customer
    public bool StatusPrinted { get; set; }
    //Time when message was received by Customer
    public DateTime DateReceived { get; set; }

    public int TimesPrinted { get; set; }
    //Customer ID
    public int CustomerId { get; set; }
}