using System.Data;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MySqlConnector;
using Xunit;

namespace Webinars.IntegrationTests;

public class WebinarFactory<TStartUp> : WebApplicationFactory<TStartUp>, IAsyncLifetime where TStartUp : class
{
    private readonly MySqlTestcontainer _dbContainer =
        new TestcontainersBuilder<MySqlTestcontainer>()
            .WithDatabase(new MySqlTestcontainerConfiguration
            {
                Database = "mydb",
                Username = "pablo",
                Password = "pablos"
            }).Build();
        
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(IDbConnection));
            var a = _dbContainer;
            services.AddSingleton<IDbConnection>(_=> 
                new MySqlConnection(_dbContainer.ConnectionString));
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}