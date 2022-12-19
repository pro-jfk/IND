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
    
    // Customer
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public ICollection<CustomerMessage> CustomerMessages { get; set; }


}