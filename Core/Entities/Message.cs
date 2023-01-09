using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core.Entities;

public class Message : BaseEntity
{
 
    // Vnumber
    public int Id { get; set; }
    // Type of message for Asielzoeker
    public string Type { get; set; }
    //public string Employee { get; set; } => FK
    //Time message was send
    public DateTime DateSent { get; set; }
    // File url
    public string FileURL { get; set; }
    
       
    //If message is received by Customer
    public bool StatusReceived { get; set; }
    //If message is printed by Customer
    public bool StatusPrinted { get; set; }
    //Time when message was received by Customer
    public DateTime DateReceived { get; set; }

    public int TimesPrinted { get; set; }
    
    // Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    // public ICollection<CustomerMessage> CustomerMessages { get; set; }


}