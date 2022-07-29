using Ganss.XSS;

namespace TinyCms.Extensions;

public static class HtmlExtensions
{
    private static readonly HtmlSanitizer htmlSanitizer = new();

    static HtmlExtensions()
    {
        htmlSanitizer.AllowedAttributes.Add("class");
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
