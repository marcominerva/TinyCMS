using TinyCms.BusinessLayer.Services.Interfaces;
using TinyCms.DataAccessLayer;
using TinyCms.Shared.Models;
using TinyCms.StorageProviders;

namespace TinyCms.BusinessLayer.Services;

public class PageService : IPageService
{
    private readonly ISqlContext context;
    private readonly IStorageProvider storageProvider;

    public PageService(ISqlContext context, IStorageProvider storageProvider)
    {
        this.context = context;
        this.storageProvider = storageProvider;
    }

    public async Task<ContentPage> GetAsync(string url)
    {
        url ??= "index";
        var query = @"SELECT p.Id, p.Title, p.Content, p.IsPublished, p.StyleSheetUrls, p.StyleSheetContent,
                      s.Id AS SiteId, s.Title AS SiteTitle, s.StyleSheetUrls AS SiteStyleSheetUrls, s.StyleSheetContent AS SiteStyleSheetContent
                      FROM ContentPages p
                      INNER JOIN Sites s ON p.SiteId = s.Id
                      WHERE [Url] = @url";

        var contentPage = await context.GetObjectAsync<ContentPage, Site, ContentPage>(query,
            map: (contentPage, site) =>
            {
                contentPage.Site = site;
                return contentPage;
            },
            param: new { url },
            splitOn: "SiteId");

        if (contentPage is not null)
        {
            var extension = Path.GetExtension(contentPage.Content)?.ToLowerInvariant();

            //if (extension == ".inc" || extension == ".md" || extension == ".htm" || extension == ".html")
            if (extension is ".inc" or ".md" or ".htm" or ".html")
            {
                var content = await storageProvider.ReadAsStringAsync(contentPage.Content);
                if (content is null)
                {
                    return null;
                }

                contentPage.Content = content;
            }
        }

        return contentPage;
    }
}
