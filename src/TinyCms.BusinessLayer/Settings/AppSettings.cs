namespace TinyCms.BusinessLayer.Settings;

public class AppSettings
{
    public Guid SiteId { get; init; }

    public string? StorageFolder { get; set; }
}
