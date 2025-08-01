using Microsoft.Extensions.DependencyInjection;

namespace TinyCms.StorageProviders.AzureStorage;

public static class AzureStorageProviderExtensions
{
    public static IServiceCollection AddAzureStorage(this IServiceCollection services, Action<AzureStorageSettings> configuration)
    {
        var settings = new AzureStorageSettings();
        configuration.Invoke(settings);

        services.AddSingleton(settings);
        services.AddSingleton<IStorageProvider, AzureStorageProvider>();

        return services;
    }
}
