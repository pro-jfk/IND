namespace App.Responses;

public class Customer_MessageResponse
{
    public bool StatusReceived { get; set; }
    public bool StatusPrinted { get; set; }
    public DateTime DateReceived { get; set; }
    
    public int MessageId { get; set; }

    public int CustomerId { get; set; }
}