// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - ItemEditTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.TagHelpers;

public class ItemEditTagHelper : ItemLinkTagHelperBase
{
    public ItemEditTagHelper(
        IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory) : base(contextAccessor, urlHelperFactory)
    {
        ActionName = nameof(CarsController.EditAsync).RemoveAsyncSuffix();
    }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        BuildContent(output, "text-warning", "Edit", "edit");
    }
}