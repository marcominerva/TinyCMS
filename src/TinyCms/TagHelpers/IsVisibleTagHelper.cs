using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TinyCms.TagHelpers;

[HtmlTargetElement(Attributes = AttributeName)]
public class IsVisibleTagHelper : TagHelper
{
    public const string AttributeName = "is-visible";

    public bool IsVisible { get; set; } = true;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (!IsVisible)
        {
            output.SuppressOutput();
        }

        base.Process(context, output);
    }
}
