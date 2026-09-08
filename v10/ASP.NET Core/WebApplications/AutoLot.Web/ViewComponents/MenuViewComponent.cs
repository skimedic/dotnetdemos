// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Web - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Web.ViewComponents;

public class MenuViewComponent(
    IMakeDataService makeDataService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var makes =
            await makeDataService.GetAllAsync() ??
            [
            ];
        return View(
            "MenuView",
            makes);
    }
}