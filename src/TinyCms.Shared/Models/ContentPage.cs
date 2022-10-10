namespace TinyCms.Shared.Models;

public class ContentPage
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public bool IsPublished { get; set; }

    public string[] StyleSheetUrls { get; set; }

    public string StyleSheetContent { get; set; }

    public Site Site { get; set; }
}