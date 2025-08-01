namespace TinyCms.Shared.Models;

public class ContentPage
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool IsPublished { get; set; }

    public string[]? StyleSheetUrls { get; set; }

    public string? StyleSheetContent { get; set; }

    public Site Site { get; set; } = null!;
}