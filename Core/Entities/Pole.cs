using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Pole
{
    public string ID { get; set; }
    
    [ForeignKey("EmergencyShelter")]
    public string Location { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
}