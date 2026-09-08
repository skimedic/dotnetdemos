// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/05
// ==================================

namespace AutoLot.Web.Pages;

public class IndexModel(
    IAppLogger appLogger,
    IOptionsSnapshot<DealerInfo> dealerOptionsSnapshot) : PageModel
{
    [BindProperty]
    public DealerInfo Entity { get; } = dealerOptionsSnapshot.Value;

    public void OnGet()
    {
        //throw new Exception("I broke it");
        //appLogger.LogAppError("Test Error");
    }
}