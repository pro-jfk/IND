namespace App.Models;

public class GetCustomerMessage
{
    //Message ID
    public int MessageId { get; set; }

    //Customer ID
    public int CustomerId { get; set; }

    public int TimesPrinted { get; set; }

    //message received
    public bool StatusReceived { get; set; }

    //message printed
    public bool StatusPrinted { get; set; }
}