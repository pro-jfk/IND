namespace App.Models;

public class AuthTokenDTO
{
    public string AuthTokenId { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
    public string token { get; set; }
    public int revoked { get; set; }


    public int PoleId { get; set; }
}