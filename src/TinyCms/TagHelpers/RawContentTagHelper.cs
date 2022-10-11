using Markdig;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TinyCms.Extensions;

namespace TinyCms.TagHelpers;

[HtmlTargetElement("raw")]
public class RawContentTagHelper : TagHelper
{
    public bool Sanitize { get; set; } = true;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync(NullHtmlEncoder.Default);
        var html = childContent.GetContent(NullHtmlEncoder.Default);
        html = Markdown.ToHtml(html);
        if (Sanitize)
        {
            html = HtmlExtensions.Sanitize(html);
        }

        output.TagName = null;
        output.Content.SetHtmlContent(html);

        await base.ProcessAsync(context, output);
    }
}
