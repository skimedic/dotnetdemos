// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/26
// ==================================

namespace AutoLot.Web.Pages;

public class IndexModel(
    IAppLogging logger,
    IOptionsSnapshot<DealerInfo> dealerOptionsSnapshot) : PageModel
{
    [BindProperty] public DealerInfo Entity { get; set; } = dealerOptionsSnapshot.Value;

    public void OnGet()
    {
        //logger.LogAppError("Test Error");
    }
}