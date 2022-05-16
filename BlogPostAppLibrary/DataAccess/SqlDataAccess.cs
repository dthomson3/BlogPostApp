using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BlogPostAppLibrary.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    public string ConnectionStringName { get; set; } = "Default";
    private readonly IConfiguration _config;

    public async Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(ConnectionStringName))
        {
            var data = await connection.QueryAsync<T>(sql, parameters);
            return data.ToList();
        }
    }

    public List<T> LoadData<T, U>(string sql, U parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(ConnectionStringName))
        {
            var data = connection.Query<T>(sql, parameters);
            return data.ToList();
        }
    }

    public async Task<T> LoadSingleDataAsync<T>(string sql)
    {

        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(ConnectionStringName))
        {
            var data = await connection.QueryAsync<T>(sql);
            return data.Single();
        }
    }

    public object LoadSingleData<T>(string sql)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(ConnectionStringName))
        {
            var data = connection.Query<T>(sql);
            return data.Single();
        }
    }

    public async Task SaveDataAsync<T>(string sql, T parameters)
    {
        string connectionString = _config.GetConnectionString(ConnectionStringName);

        using (IDbConnection connection = new SqlConnection(ConnectionStringName))
        {
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
