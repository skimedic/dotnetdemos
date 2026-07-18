// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Route("[area]/[controller]/[action]")]
public class MakesController(
    IAppLogging appLogging,
    IMakeDataService makeDataService) : BaseCrudController<Make>(appLogging, makeDataService)
{
    // GET: Admin/Makes
    [Route("/Admin")]
    [Route("/Admin/[controller]")]
    [Route("/Admin/[controller]/[action]")]
    public override Task<IActionResult> IndexAsync() => base.IndexAsync();

}
