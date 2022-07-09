namespace Webinars.Dapper.MySQL.Config;

public class SqlServerConfig : ISqlServerConfig
{
    public SqlServerConfig(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; init; }
}