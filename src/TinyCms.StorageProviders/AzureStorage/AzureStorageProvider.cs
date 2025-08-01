using Azure.Storage.Blobs;

namespace TinyCms.StorageProviders.AzureStorage;

internal class AzureStorageProvider(AzureStorageSettings settings) : IStorageProvider
{
    private readonly BlobServiceClient blobServiceClient = new(settings.ConnectionString);

    public async Task<Stream?> ReadAsStreamAsync(string path)
    {
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(settings.ContainerName);
        var blobClient = blobContainerClient.GetBlobClient(path);

        try
        {
            var stream = await blobClient.OpenReadAsync();
            return stream;
        }
        catch
        {
            return null;
        }
    }
}
