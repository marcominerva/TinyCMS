using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TinyCms.DataAccessLayer;

internal class SqlContext : ISqlContext
{
    private IDbConnection connection;
    private bool disposedValue;

    private IDbConnection Connection
    {
        get
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }
    }

    public SqlContext(SqlContextOptions options)
    {
        connection = new SqlConnection(options.ConnectionString);
    }

    public Task<IEnumerable<T>> GetDataAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        where T : class
        => Connection.QueryAsync<T>(sql, param, transaction, commandType: commandType);

    public Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
        where TFirst : class
        where TSecond : class
        where TReturn : class
        => Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType);

    public Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TThrid, TReturn>(string sql, Func<TFirst, TSecond, TThrid, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
        where TFirst : class
        where TSecond : class
        where TThrid : class
        where TReturn : class
        => Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType);

    public Task<IEnumerable<TReturn>> GetDataAsync<TFirst, TSecond, TThrid, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThrid, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
        where TFirst : class
        where TSecond : class
        where TThrid : class
        where TFourth : class
        where TReturn : class
        => Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType);

    public Task<T> GetObjectAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        where T : class
        => Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandType: commandType);

    public async Task<TReturn> GetObjectAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
        where TFirst : class
        where TSecond : class
        where TReturn : class
    {
        var result = await Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
        return result.FirstOrDefault();
    }

    public async Task<TReturn> GetObjectAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
        where TFirst : class
        where TSecond : class
        where TThird : class
        where TReturn : class
    {
        var result = await Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
        return result.FirstOrDefault();
    }

    public async Task<TReturn> GetObjectAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, CommandType? commandType = null, string splitOn = "Id")
        where TFirst : class
        where TSecond : class
        where TThird : class
        where TFourth : class
        where TReturn : class
    {
        var result = await Connection.QueryAsync(sql, map, param, transaction, splitOn: splitOn, commandType: commandType).ConfigureAwait(false);
        return result.FirstOrDefault();
    }

    public Task<T> GetSingleValueAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
        => Connection.ExecuteScalarAsync<T>(sql, param, transaction, commandType: commandType);

    public Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CommandType? commandType = null)
       => Connection.ExecuteAsync(sql, param, transaction, commandType: commandType);

    public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        => Connection.BeginTransaction(isolationLevel);

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                if (connection?.State == ConnectionState.Open)
                {
                    connection.Close();
                }

                connection?.Dispose();
                connection = null;
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
