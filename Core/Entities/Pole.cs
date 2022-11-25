using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Pole
{
    public int Id { get; set; }
    
    
    public int EmergencyShelterId { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
}