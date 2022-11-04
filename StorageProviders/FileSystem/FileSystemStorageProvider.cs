namespace StorageProviders.FileSystem;

internal class FileSystemStorageProvider : IStorageProvider
{
    private readonly FileSystemSettings settings;

    public FileSystemStorageProvider(FileSystemSettings settings)
    {
        this.settings = settings;
    }

    public Task<Stream> ReadAsStreamAsync(string path)
    {
        path = Path.Combine(settings.StorageFolder, path);
        if (!Path.IsPathRooted(path))
        {
            path = Path.Combine(AppContext.BaseDirectory, path);
        }

        if (!File.Exists(path))
        {
            return null;
        }

        var stream = File.OpenRead(path);
        return Task.FromResult(stream as Stream);
    }
}
