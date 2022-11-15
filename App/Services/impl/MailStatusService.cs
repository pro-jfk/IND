using Core.Entities.Mail;

namespace App.Services.impl;

public class MailStatusService : IMailStatusService
{
    public async Task<MailStatus> Get(int id)
    {
        var date = DateTime.Now;
        MailStatus mail = new MailStatus()
        {
            Message = "Lorum Ipsum",
            Printed = false,
            Read = false,
            VNumber = id,
            DateSent = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute,date.Second, date.Kind).ToString()
        };
        return mail;
    }
}