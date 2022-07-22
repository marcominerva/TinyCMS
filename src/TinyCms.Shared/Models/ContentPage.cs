namespace TinyCms.Shared.Models;

public class ContentPage
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public bool IsPublished { get; set; }

    public Site Site { get; set; }
}

public class Site
{
    public Guid Id { get; set; }

    public string Title { get; set; }
}