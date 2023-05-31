using Data.Repositories;
using Data.Repositories.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmergencyShelterRepository, EmergencyShelterRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IPoleRepository, PoleRepository>();
        services.AddScoped<ICustomerMessageRepository, CustomerMessageRepository>();
    }
}