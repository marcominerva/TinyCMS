namespace TinyCms.StorageProviders;

public interface IStorageProvider
{
    Task<Stream> ReadAsStreamAsync(string path);

    async Task<string> ReadAsStringAsync(string path)
    {
        using var input = await ReadAsStreamAsync(path);
        if (input is null)
        {
            return null;
        }

        using var reader = new StreamReader(input);

        var content = await reader.ReadToEndAsync();
        return content;
    }
}
