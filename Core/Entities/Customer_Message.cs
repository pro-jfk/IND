using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;


public class Customer_Message
{
    //If message is recieved by Customer
    public bool StatusReceived { get; set; }
    //If message is printed by Customer
    public bool StatusPrinted { get; set; }
    //Time when message was recieved by Customer
    public DateTime DateReceived { get; set; }
    
    //Message
    public int MessageId { get; set; }
    public Message Message { get; set; }
    
    //Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }


}