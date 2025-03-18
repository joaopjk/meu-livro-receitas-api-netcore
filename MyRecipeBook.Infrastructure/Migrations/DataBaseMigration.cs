using Dapper;
using Microsoft.Data.SqlClient;

namespace MyRecipeBook.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public static void Migrate(string connectionString)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            var databaseName = connectionStringBuilder.InitialCatalog;
            connectionStringBuilder.Remove("Database");

            using var dbConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT COUNT(*) FROM sys.databases WHERE name = @name", parameters);
            if (!records.Any())
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
        }
    }
}
