namespace App.Models;

public class CreateCustomerMessage
{
    //Message received
    public bool StatusReceived { get; set; }
    //Message printed
    public bool StatusPrinted { get; set; }
    //Date when message was received
    public DateTime DateReceived { get; set; }

    public int TimesPrinted { get; set; }
    
    //Message ID
    public int MessageId { get; set; }

    //Customer ID
    public int CustomerId { get; set; }
}