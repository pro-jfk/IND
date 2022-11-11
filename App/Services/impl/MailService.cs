using Core.Entities;

namespace App.Services.impl;

public class MailService
{
    public static Mail Get(int id)
    {
        Mail mail = new Mail()
        {
            Message = "Lorum Ipsum",
            Vnumber = id
        };
        return mail;
    }
}