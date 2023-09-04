using System.Text.RegularExpressions;
using Markdig;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TinyCms.Extensions;

namespace TinyCms.TagHelpers;

[HtmlTargetElement("raw")]
public partial class RawContentTagHelper : TagHelper
{
    [GeneratedRegex("<(?:\"[^\"]*\"['\"]*|'[^']*'['\"]*|[^'\">])+>")]
    private static partial Regex htmlRegex();

    private static readonly MarkdownPipeline markdownPipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

    public bool Sanitize { get; set; } = true;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync(NullHtmlEncoder.Default);
        var content = childContent.GetContent(NullHtmlEncoder.Default);

        var isHtml = htmlRegex().IsMatch(content);
        if (!isHtml)
        {
            content = Markdown.ToHtml(content, markdownPipeline);
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
