using Microsoft.Extensions.DependencyInjection;

namespace StorageProviders.AzureStorage;

public static class AzureStorageProviderExtensions
{
    public static IServiceCollection AddAzureStorage(this IServiceCollection services, Action<AzureStorageSettings> configuration)
    {
        var settings = new AzureStorageSettings();
        configuration.Invoke(settings);

        services.AddSingleton(settings);
        services.AddScoped<IStorageProvider, AzureStorageProvider>();

        return services;
    }
}
