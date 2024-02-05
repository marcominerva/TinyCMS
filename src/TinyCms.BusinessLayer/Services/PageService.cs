using Microsoft.Extensions.Options;
using TinyCms.BusinessLayer.Services.Interfaces;
using TinyCms.BusinessLayer.Settings;
using TinyCms.DataAccessLayer;
using TinyCms.Shared.Models;
using TinyCms.StorageProviders;

namespace TinyCms.BusinessLayer.Services;

public class PageService(ISqlContext context, IStorageProvider storageProvider, IOptions<AppSettings> appSettingsOptions) : IPageService
{
    public async Task<ContentPage> GetAsync(string url)
    {
        url ??= "index";
        var query = """
                    SELECT p.Id, p.Title, p.Content, p.IsPublished, p.StyleSheetUrls, p.StyleSheetContent,
                        s.Id AS SiteId, s.Title AS SiteTitle, s.LogoUrl, s.ShowLogoOnly, s.StyleSheetUrls AS SiteStyleSheetUrls, s.StyleSheetContent AS SiteStyleSheetContent
                    FROM ContentPages p
                    INNER JOIN Sites s ON p.SiteId = s.Id
                    WHERE s.Id = @siteId AND p.Url = @url AND s.IsPublished = 1
                    """;

        var contentPage = await context.GetObjectAsync<ContentPage, Site, ContentPage>(query,
            map: (contentPage, site) =>
            {
                contentPage.Site = site;
                return contentPage;
            },
            param: new { appSettingsOptions.Value.SiteId, url },
            splitOn: "SiteId");

        if (contentPage is not null)
        {
            var extension = Path.GetExtension(contentPage.Content)?.ToLowerInvariant();

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
