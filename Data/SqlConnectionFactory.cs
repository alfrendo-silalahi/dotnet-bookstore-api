using System.Data;
using BookStoreApi.Data;
using Microsoft.Data.SqlClient;

namespace BookStoreApi.Data;

public class SqlConnectionFactory(IConfiguration config) : IDbConnectionFactory
{
    private readonly string _connectionString =
        config.GetConnectionString("Default")
        ?? throw new InvalidOperationException("Connection string 'Default' not found.");

    public IDbConnection Create() => new SqlConnection(_connectionString);
}