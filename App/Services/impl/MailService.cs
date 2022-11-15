using Core.Entities.Mail;

namespace App.Services.impl;

public class MailService : IMailService
{
    public async Task<Mail> Get(int id)
    {
        Mail mail = new Mail()
        {
            Message = "Lorum Ipsum",
            Vnumber = id
        };
        return mail;
    }
}