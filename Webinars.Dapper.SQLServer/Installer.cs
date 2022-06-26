using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Webinars.Contracts.Persistence;
using Webinars.Dapper.SQLServer.Repository;

namespace Webinars.Dapper.SQLServer
{
    public static class Installer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IDbConnection, SqlConnection>(
                (services) => new SqlConnection("Data Source=localhost;Initial Catalog=Webinars;Integrated Security=True"));
            services.AddScoped<IWebinarRepository,WebinarRepository>();
            return services;
        } 
    }
}