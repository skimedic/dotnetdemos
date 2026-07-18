// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - ItemLinkTagHelperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.TagHelpers.Base;

public abstract class ItemLinkTagHelperBase : TagHelper
{
    private readonly string _controllerName;
    protected string ActionName { get; set; }
    protected readonly IUrlHelper UrlHelper;
    public int? ItemId { get; set; }

    protected ItemLinkTagHelperBase(
        IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory)
    {
        var httpContext = contextAccessor.HttpContext;
        var endpoint = httpContext?.GetEndpoint();
        var actionDescriptor = endpoint?.Metadata.GetMetadata<ActionDescriptor>() as ControllerActionDescriptor;
        ActionName = actionDescriptor?.ActionName;
        _controllerName = actionDescriptor?.ControllerName;
        UrlHelper =
            urlHelperFactory.GetUrlHelper(new ActionContext
            {
                HttpContext = httpContext,
                RouteData = httpContext.GetRouteData(),
                ActionDescriptor = actionDescriptor
            });
    }

    protected void BuildContent(
        TagHelperOutput output,
        string cssClassName,
        string displayText,
        string fontAwesomeName)
    {
        output.TagName = "a"; // Replaces <email> with <a> tag
        var target =
            (ItemId.HasValue)
                ? UrlHelper.Action(ActionName, _controllerName, new
                {
                    id = ItemId
                })
                : UrlHelper.Action(ActionName, _controllerName);
        output.Attributes.SetAttribute("href", target);
        output.Attributes.Add("class", cssClassName);
        output.Content.AppendHtml($@"{displayText} <i class=""fa-solid fa-{fontAwesomeName}""></i>");
    }
}
