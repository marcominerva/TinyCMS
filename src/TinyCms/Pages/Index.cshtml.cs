using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyCms.BusinessLayer.Services.Interfaces;
using TinyCms.Shared.Models;

namespace TinyCms.Pages;

public class IndexModel : PageModel
{
    private readonly IPageService pageService;

    public ContentPage ContentPage { get; set; }

    public IndexModel(IPageService pageService)
    {
        this.pageService = pageService;
    }

    public async Task<IActionResult> OnGetAsync(string url)
    {
        ContentPage = await pageService.GetAsync(url);

        if (ContentPage is null)
        {
            return NotFound();
        }

        if (!ContentPage.IsPublished)
        {
            return StatusCode(StatusCodes.Status403Forbidden);
        }

        return Page();
    }
}
