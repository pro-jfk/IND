using Core.Entities.Mail;

namespace App.Services;

public interface IMailStatusService
{
    Task<MailStatus> Get(int id);
}