using System.Data;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Webinars.Contracts.Persistence;
using Webinars.Dapper.MySQL.Repository;

namespace Webinars.Dapper.MySQL
{
    public static class Installer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IDbConnection, MySqlConnection>(
                (services) => new MySqlConnection("Server=127.0.0.1;User ID = adminNET; Password=admin;Database=webinar"));
            services.AddScoped<IWebinarRepository,WebinarRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        } 
    }
}