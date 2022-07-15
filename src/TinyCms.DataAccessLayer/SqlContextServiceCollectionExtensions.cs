using Microsoft.Extensions.DependencyInjection;

namespace TinyCms.DataAccessLayer;

public static class SqlContextServiceCollectionExtensions
{
    public static IServiceCollection AddSqlContext(this IServiceCollection services, Action<SqlContextOptions> configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        var options = new SqlContextOptions();
        configuration.Invoke(options);

        services.AddSingleton(options);
        services.AddScoped<ISqlContext, SqlContext>();

        return services;
    }
}
