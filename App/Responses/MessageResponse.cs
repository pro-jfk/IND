namespace App.Responses;

public class MessageResponse
{
    public int Id { get; set; }

    //Type of message
    public string Type { get; set; }

    //File url
    public string FileURL { get; set; }
}