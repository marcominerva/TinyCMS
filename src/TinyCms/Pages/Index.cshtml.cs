using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TinyCms.DataAccessLayer;

namespace TinyCms.Pages;

public class IndexModel : PageModel
{
    private readonly ISqlContext sqlContext;

    public IndexModel(ISqlContext sqlContext)
    {
        this.sqlContext = sqlContext;
    }

    public async Task OnGetAsync(string url)
    {
        var contentPages = await sqlContext.GetSingleValueAsync<int>("SELECT COUNT(*) FROM ContentPages");
        Debug.WriteLine(contentPages);
    }
}
