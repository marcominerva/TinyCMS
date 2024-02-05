using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyCms.BusinessLayer.Services.Interfaces;
using TinyCms.Shared.Models;

namespace TinyCms.Pages;

public class IndexModel(IPageService pageService) : PageModel
{
    public ContentPage ContentPage { get; set; }

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
