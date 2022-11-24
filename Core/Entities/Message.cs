using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core.Entities;

public class Message : BaseEntity
{
 
    public int Id { get; set; }
    public string Type { get; set; }
    //public string Employee { get; set; } => FK
    public DateTime DateSent { get; set; }
    public string FileURL { get; set; }
    
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

}