using App.Models;
using Core.Entities.Mail;

namespace App.Services.impl;

public class MailService : IMailService
{
    public async Task<Mail> Get(int id)
    {
        if (id.ToString().Length != 10)
        {
            return new Mail();
        }

        if (id != ExampleVNumber)
        {
            return new Mail();
        }
        
        Mail mail = new Mail()
        {
            Message = "Lorum Ipsum",
            Vnumber = id
        };
        return mail;
    }

    public int ExampleVNumber = 1234567890;
    public string ExampleMessage = "Lorum ipsum";
}