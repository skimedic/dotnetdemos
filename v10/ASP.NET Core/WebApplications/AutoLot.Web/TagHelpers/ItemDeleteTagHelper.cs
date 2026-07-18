// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - ItemDeleteTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Web.TagHelpers;

public class ItemDeleteTagHelper : ItemLinkTagHelperBase
{
    public ItemDeleteTagHelper(
        IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory) : base(contextAccessor, urlHelperFactory)
    {
        ActionName = "Delete";
    }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        BuildContent(output, "text-danger", "Delete", "trash");
    }
}