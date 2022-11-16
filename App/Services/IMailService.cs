using Core.Entities.Mail;

namespace App.Services;

public interface IMailService
{
    Task<Mail> Get(int id);
    Task<Mail> CreateMail(Mail mail);
    Task<bool> DeleteMail(int id);
}