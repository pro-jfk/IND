using App.MappingProfile;
using App.Services;
using App.Services.impl;
using Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddServices();
        services.RegisterAutoMapper();
        return services;
    }
    
    private static void AddServices(this IServiceCollection services)
    {
        //services.AddScoped<IMailService, MailService>();
        //services.AddScoped<IMailStatusService, MailStatusService>();
        services.AddScoped<IEmergencyShelterService, EmergencyShelterService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<ICustomerMessageService, CustomerMessageService>();
    }

    private static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IMappingProfilesMarker));
    }
}