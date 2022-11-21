namespace App.Models;

public class Customer_MessageResponse
{
    public bool StatusReceived { get; set; }
    public bool StatusPrinted { get; set; }
    public DateTime DateReceived { get; set; }
    
    public int MessageID { get; set; }

    public int CustomerID { get; set; }
}