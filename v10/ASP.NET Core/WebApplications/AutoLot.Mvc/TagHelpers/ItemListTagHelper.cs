// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - ItemListTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.TagHelpers;

public class ItemListTagHelper : ItemLinkTagHelperBase
{
    public ItemListTagHelper(
        IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory) : base(contextAccessor, urlHelperFactory)
    {
        ActionName = nameof(CarsController.IndexAsync).RemoveAsyncSuffix();
    }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        BuildContent(output, "text-default", "Back to List", "list");
    }
}