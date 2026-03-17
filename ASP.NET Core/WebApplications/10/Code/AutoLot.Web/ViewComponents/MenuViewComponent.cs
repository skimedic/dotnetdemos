// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Web.ViewComponents;

public class MenuViewComponent(IMakeDataService makeDataService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var makes = (await makeDataService.GetAllAsync()).ToList();
        if (!makes.Any())
        {
            return new ContentViewComponentResult("Unable to get the makes");
        }

        return View("MenuView", makes);
    }
}