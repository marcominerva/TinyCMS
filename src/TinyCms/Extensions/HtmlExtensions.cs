using Ganss.Xss;

namespace TinyCms.Extensions;

public static class HtmlExtensions
{
    private static readonly HtmlSanitizer htmlSanitizer = new();

    static HtmlExtensions()
    {
        htmlSanitizer.AllowedAttributes.Add("class");
        htmlSanitizer.AllowedTags.Add("style");
    }

    public static string Sanitize(string html)
    {
        if (html is null)
        {
            return null;
        }

        var sanitized = htmlSanitizer.Sanitize(html);
        return sanitized;
    }
}
