using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Pole
{
    // Vnumber
    public int Id { get; set; }
    
    //Location of COA location
    public int EmergencyShelterId { get; set; }
    public EmergencyShelter EmergencyShelter { get; set; }
}