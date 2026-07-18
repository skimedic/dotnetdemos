// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.ViewComponents;

public class MenuViewComponent(
    IMakeDataService makeDataService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var makes = await makeDataService.GetAllAsync() ?? [];
        return View("MenuView", makes);
    }
    //public async Task<IViewComponentResult> InvokeAsync()
    //{
    //    return await Task.Run<IViewComponentResult>(() =>
    //    {
    //        var makes = makeRepo.GetAllAsList() ?? [];
    //        return View("MenuView", makes);
    //    });
    //}
}
