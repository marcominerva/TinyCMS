using Microsoft.Extensions.DependencyInjection;

namespace TinyCms.StorageProviders.FileSystem;

public static class FileSystemStorageProviderExtensions
{
    public static IServiceCollection AddFileSystemStorage(this IServiceCollection services, Action<FileSystemSettings> configuration)
    {
        var settings = new FileSystemSettings();
        configuration.Invoke(settings);

        services.AddSingleton(settings);
        services.AddSingleton<IStorageProvider, FileSystemStorageProvider>();

        return services;
    }
}
