// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - ItemLinkTagHelperBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================


namespace AutoLot.Web.TagHelpers.Base;

public abstract class ItemLinkTagHelperBase : TagHelper
{
    protected readonly IUrlHelper UrlHelper;
    public int? ItemId { get; set; }
    private readonly string _pageName;
    protected string ActionName { get; set; }

    protected ItemLinkTagHelperBase(IHttpContextAccessor contextAccessor,
        IUrlHelperFactory urlHelperFactory)
    {
        //UrlHelper = urlHelperFactory.GetUrlHelper(contextAccessor.HttpContext.GetEndpoint()?.Metadata.GetMetadata<ActionDescriptor>());
        var httpContext = contextAccessor.HttpContext;
        var endpoint = httpContext?.GetEndpoint();
        var actionDescriptor = endpoint?.Metadata.GetMetadata<ActionDescriptor>() as ControllerActionDescriptor;
        UrlHelper = urlHelperFactory.GetUrlHelper(new ActionContext
        {
            HttpContext = httpContext,
            RouteData = httpContext.GetRouteData(),
            ActionDescriptor = actionDescriptor
        });
        var pageRouteValue = httpContext?.GetRouteData()?.Values["page"] as string;
        _pageName = pageRouteValue?.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
    }

    protected void BuildContent(TagHelperOutput output,
      string cssClassName, string displayText, string fontAwesomeName)
    {
        output.TagName = "a";
        var target = ItemId.HasValue
          ? UrlHelper.Page($"/{_pageName}/{ActionName}", new { id = ItemId })
          : UrlHelper.Page($"/{_pageName}/{ActionName}");
        output.Attributes.SetAttribute("href", target);
        output.Attributes.Add("class", cssClassName);
        output.Content.AppendHtml($@"{displayText} <i class=""fa-solid fa-{fontAwesomeName}""></i>");
    }
}
