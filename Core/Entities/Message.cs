using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Message
{
    public string ID { get; set; }
    public string Type { get; set; }
    //public string Employee { get; set; } => FK
    public DateTime DateSent { get; set; }
    public string FileURL { get; set; }
    
    [ForeignKey("Customer")]
    public int customer { get; set; }
    public Customer Customer { get; set; }

}