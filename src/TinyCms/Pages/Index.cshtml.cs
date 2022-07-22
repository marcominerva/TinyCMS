using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyCms.BusinessLayer.Services.Interfaces;

namespace TinyCms.Pages;

public class IndexModel : PageModel
{
    private readonly IPageService pageService;

    public IndexModel(IPageService pageService)
    {
        this.pageService = pageService;
    }

    public async Task OnGetAsync(string url)
    {
        var contentPage = await pageService.GetAsync(url);
        Debug.WriteLine(contentPage.Title);
    }
}
