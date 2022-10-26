using AngleSharp.Css.Dom;
using AngleSharp.Svg.Dom;
using Ganss.Xss;

namespace TinyCms.Extensions;

public static class HtmlExtensions
{
    private static readonly HtmlSanitizer htmlSanitizer = new();

    static HtmlExtensions()
    {
        htmlSanitizer.AllowedAttributes.Add("class");
        htmlSanitizer.AllowedTags.Add("style");
        htmlSanitizer.AllowedSchemes.Add("data");

        htmlSanitizer.AllowedCssProperties.Add("fill");
        htmlSanitizer.AllowedCssProperties.Add("transform-box");

        htmlSanitizer.AllowedAtRules.Add(CssRuleType.FontFace);
        htmlSanitizer.AllowedAtRules.Add(CssRuleType.Charset);
        htmlSanitizer.AllowedAtRules.Add(CssRuleType.Viewport);
        htmlSanitizer.AllowedAtRules.Add(CssRuleType.Media);
        htmlSanitizer.AllowedAtRules.Add(CssRuleType.Keyframes);
        htmlSanitizer.AllowedAtRules.Add(CssRuleType.Keyframe);
        htmlSanitizer.AllowedAtRules.Add(CssRuleType.Page);

        htmlSanitizer.RemovingTag += (s, e) => e.Cancel = e.Tag is SvgElement;
        htmlSanitizer.RemovingAttribute += (s, e) => e.Cancel = e.Tag is SvgElement;
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
