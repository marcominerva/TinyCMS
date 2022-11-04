using Microsoft.Extensions.DependencyInjection;

namespace StorageProviders.FileSystem;

public static class FileSystemStorageProviderExtensions
{
    public static IServiceCollection AddFileSystemStorage(this IServiceCollection services, Action<FileSystemSettings> configuration)
    {
        var settings = new FileSystemSettings();
        configuration.Invoke(settings);

        services.AddSingleton(settings);
        services.AddScoped<IStorageProvider, FileSystemStorageProvider>();

        return services;
    }
}
