namespace Core.Entities;

public class AuthTokens
{
    public string ID { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
    public string token { get; set; }
    public int revoked { get; set; }
    
    //FK Pole or CUstomer??
}