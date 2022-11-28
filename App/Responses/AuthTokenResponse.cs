namespace App.Responses;

public class AuthTokenResponse
{
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
}