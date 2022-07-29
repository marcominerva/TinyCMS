using Microsoft.AspNetCore.Razor.TagHelpers;
using TinyCms.Extensions;

namespace TinyCms.TagHelpers;

[HtmlTargetElement("raw")]
public class RawContentTagHelper : TagHelper
{
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var html = (await output.GetChildContentAsync(NullHtmlEncoder.Default)).GetContent(NullHtmlEncoder.Default);
        html = HtmlExtensions.Sanitize(html);

        output.TagName = null;
        output.Content.SetHtmlContent(html);

        await base.ProcessAsync(context, output);
    }
}
