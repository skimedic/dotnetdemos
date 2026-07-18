// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - ItemListTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.TagHelpers;

public class ItemListTagHelper : ItemLinkTagHelperBase
{
    public ItemListTagHelper(
        IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory) : base(contextAccessor, urlHelperFactory)
    {
        ActionName = "Index";
    }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        BuildContent(output, "text-default", "Back to List", "list");
    }
}