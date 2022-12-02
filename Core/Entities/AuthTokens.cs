using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class AuthTokens
{
    //id
    public string Id { get; set; }
    //Name
    public string name { get; set; }
    //Slug
    public string slug { get; set; }
    //Token
    public string token { get; set; }
    //Revoked
    public int revoked { get; set; }

    //Pole
    public int PoleId { get; set; }
    public Pole Pole { get; set; }
}