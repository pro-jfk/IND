namespace App.Responses;

public class Customer_MessageResponse
{
    //If message is recieved by Customer
    public bool StatusReceived { get; set; }
    //If message is printed by Customer
    public bool StatusPrinted { get; set; }
    //Time when message was recieved by Customer
    public DateTime DateReceived { get; set; }
    
    //Message ID
    public int MessageId { get; set; }

    //Customer ID
    public int CustomerId { get; set; }
}