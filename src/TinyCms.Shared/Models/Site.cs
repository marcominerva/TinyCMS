namespace TinyCms.Shared.Models;

public class Site
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string StyleSheetUrls { get; set; }

    public string StyleSheetContent { get; set; }
}