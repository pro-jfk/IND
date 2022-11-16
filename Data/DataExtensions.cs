using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class DataExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("default");

        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
        return services;
    }
}