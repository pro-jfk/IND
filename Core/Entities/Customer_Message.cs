using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;


public class Customer_Message
{
    
    public bool StatusReceived { get; set; }
    public bool StatusPrinted { get; set; }
    public DateTime DateReceived { get; set; }
    
    
    public int MessageId { get; set; }
    public Message Message { get; set; }
    
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }


}