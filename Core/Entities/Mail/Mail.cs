namespace Core.Entities.Mail;

public class Mail
{
    public int Id { get; set; }
    public int Vnumber { get; set; }
    public string Message { get; set; }
    public virtual MailStatus MailStatus { get; set; }
}