namespace Webinars.Dapper.MySQL.Config
{
    public class SqlServerConfig : ISqlServerConfig
    {
        public string ConnectionString { get; init; }

        public SqlServerConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }
        
    }
}