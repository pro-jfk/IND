// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace Data;
//
// public static class DependencyInjection
// {
//     public static IServiceCollection AddDataAccess( this IServiceCollection services, IConfiguration configuration)
//     {
//         services.AddDatabase(configuration);
//
//         return services;
//     }
//
//     private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
//     {
//         var sqlConnectionString = "server=localhost;userid=root;password=2c0a59e4;database=ind_pussy;";
//
//         services.AddDbContext<IndContext>(
//             options =>
//
//                 options.UseSqlServer(sqlConnectionString,
//                     opt =>
//                     {
//                         opt.MigrationsAssembly(typeof(IndContext).Assembly.FullName);
//                         opt.EnableRetryOnFailure();
//                     })
//         );
//     }
//
// }