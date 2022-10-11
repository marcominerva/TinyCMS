using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TinyCms.Extensions;
using Westwind.AspNetCore.Markdown;

namespace TinyCms.TagHelpers;

[HtmlTargetElement("raw")]
public class RawContentTagHelper : TagHelper
{
    public bool Sanitize { get; set; } = true;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync(NullHtmlEncoder.Default);
        var html = childContent.GetContent(NullHtmlEncoder.Default);

        if (Sanitize)
        {
            html = HtmlExtensions.Sanitize(html);
        }

        html = Markdown.Parse(NormalizeWhiteSpaceText(html));

        output.TagName = null;
        output.Content.SetHtmlContent(html);

        await base.ProcessAsync(context, output);
    }

    private string NormalizeWhiteSpaceText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var lines = GetLines(text);
        if (lines.Length < 1)
            return text;

        string line1 = null;

        // find first non-empty line
        for (int i = 0; i < lines.Length; i++)
        {
            line1 = lines[i];
            if (!string.IsNullOrEmpty(line1))
                break;
        }

        if (string.IsNullOrEmpty(line1))
            return text;

        string trimLine = line1.TrimStart();
        int whitespaceCount = line1.Length - trimLine.Length;
        if (whitespaceCount == 0)
            return text;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length > whitespaceCount)
                sb.AppendLine(lines[i].Substring(whitespaceCount));
            else
                sb.AppendLine(lines[i]);
        }

        return sb.ToString();
    }

    private string[] GetLines(string s, int maxLines = 0)
    {
        if (s == null)
            return null;

        s = s.Replace("\r\n", "\n");

        if (maxLines < 1)
            return s.Split(new char[] { '\n' });

        return s.Split(new char[] { '\n' }).Take(maxLines).ToArray();
    }
}
