using System.ComponentModel.DataAnnotations.Schema;
using Core.Common;

namespace Core.Entities;

public class Pole : BaseEntity
{
    // PoleNumber
    public int Id { get; set; }

    //Location of COA location
    public int EmergencyShelterId { get; set; }
    // public EmergencyShelter EmergencyShelter { get; set; }
}