using Core.Entities.Mail;

namespace App.Services;

public interface IMailService
{
    Task<Mail> Get(int id);
}