using Azure.Storage.Blobs;

namespace StorageProviders.AzureStorage;

internal class AzureStorageProvider : IStorageProvider
{
    private readonly BlobServiceClient blobServiceClient;
    private readonly AzureStorageSettings settings;

    public AzureStorageProvider(AzureStorageSettings settings)
    {
        this.settings = settings;
        blobServiceClient = new BlobServiceClient(settings.ConnectionString);
    }

    public async Task<Stream> ReadAsStreamAsync(string path)
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
