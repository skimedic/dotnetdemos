// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Mvc - ItemDeleteTagHelper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Mvc.TagHelpers;

public class ItemDeleteTagHelper : ItemLinkTagHelperBase
{
    public ItemDeleteTagHelper(
        IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory) : base(
        contextAccessor,
        urlHelperFactory)
    {
        ActionName =
            nameof(CarsController.DeleteAsync)
                .RemoveAsyncSuffix();
    }

    public override void Process(
        TagHelperContext context,
        TagHelperOutput output)
    {
        BuildContent(
            output,
            "text-danger",
            "Delete",
            "trash");
    }
}