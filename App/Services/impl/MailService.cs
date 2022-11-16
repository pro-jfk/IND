using App.Models;
using Core.Entities.Mail;
using Data;

namespace App.Services.impl;

public class MailService : IMailService
{
    private readonly ApplicationDbContext _dbContext;

    public MailService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Mail> CreateMail(Mail mail)
    {
        var result = await _dbContext.Mails.AddAsync(mail);
        await _dbContext.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns>true if succeeded</returns>
    public async Task<bool> DeleteMail(int id)
    {
        var test = await _dbContext.Mails.FindAsync(id);
        if (test == null)
        {
            return false;
        }
        
        _dbContext.Mails.Remove(test);
        await _dbContext.SaveChangesAsync();
        return true;
    }

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