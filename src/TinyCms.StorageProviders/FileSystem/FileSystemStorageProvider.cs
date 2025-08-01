namespace TinyCms.StorageProviders.FileSystem;

internal class FileSystemStorageProvider(FileSystemSettings settings) : IStorageProvider
{
    public Task<Stream?> ReadAsStreamAsync(string path)
    {
        path = Path.Combine(settings.StorageFolder ?? string.Empty, path);
        if (!Path.IsPathRooted(path))
        {
            path = Path.Combine(settings.SiteRootFolder ?? string.Empty, path);
        }

        if (!File.Exists(path))
        {
            return Task.FromResult<Stream?>(null);
        }

        var stream = File.OpenRead(path);
        return Task.FromResult<Stream?>(stream);
    }
}
