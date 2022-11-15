using App.Services;
using App.Services.impl;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        return services;
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IMailStatusService, MailStatusService>();
    }
}