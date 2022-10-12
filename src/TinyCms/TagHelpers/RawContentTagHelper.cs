using System.Text.RegularExpressions;
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
        var content = childContent.GetContent(NullHtmlEncoder.Default);

        var isHtml = Regex.Match(content, "<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>");
        if (!isHtml.Success)
        {
            content = Markdown.ToHtml(content);
        }

        if (Sanitize)
        {
            content = HtmlExtensions.Sanitize(content);
        }

        output.TagName = null;
        output.Content.SetHtmlContent(content);

        await base.ProcessAsync(context, output);
    }
}
