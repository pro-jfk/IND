namespace App.Models;

public class GetCustomer_Message
{

    public int MessageId { get; set; }
    public int CustomerId { get; set; }
    
    public bool StatusReceived { get; set; }
    public bool StatusPrinted { get; set; }
}

