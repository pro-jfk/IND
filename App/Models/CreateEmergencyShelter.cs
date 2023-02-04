namespace App.Models;

public class CreateEmergencyShelter
{
    public int Id { get; set; }

    //Town name
    public string Town { get; set; }

    //Town Adress
    public string Adress { get; set; }

    //CustomerAmount
    public int CustomerAmount { get; set; }
}