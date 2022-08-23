using TinyCms.BusinessLayer.Services.Interfaces;
using TinyCms.DataAccessLayer;
using TinyCms.Shared.Models;

namespace TinyCms.BusinessLayer.Services;

public class PageService : IPageService
{
    private readonly ISqlContext context;

    public PageService(ISqlContext context)
    {
        this.context = context;
    }

    public async Task<ContentPage> GetAsync(string url)
    {
        url ??= "index";
        var query = @"SELECT p.Id, p.Title, p.Content, p.IsPublished, p.StyleSheetUrls, p.StyleSheetContent
                      , s.Id AS SiteId, s.Title AS SiteTitle, s.StyleSheetUrls AS SiteStyleSheetUrls, s.StyleSheetContent AS SiteStyleSheetContent
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

        return contentPage;
    }
}
