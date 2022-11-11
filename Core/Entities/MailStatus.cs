namespace Core.Entities;

public class MailStatus
{
    public int VNumber { get; set; }
    public bool Read { get; set; }
    public bool Printed { get; set; }
    public string Message { get; set; }
    public string DateSent { get; set; }
}