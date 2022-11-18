using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;


public class Customer_Message
{
    //TODO Configuring PK AND FK
    public bool StatusReceived { get; set; }
    public bool StatusPrinted { get; set; }
    public DateTime DateReceived { get; set; }
    
    
    public string MessageID { get; set; }
    public Message Message { get; set; }
    
    
    public int CustomerID { get; set; }
    public Customer Customer { get; set; }


}