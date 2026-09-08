// Copyright Information
// ==================================
// AutoLot-WebApps - AutoLot.Mvc - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Route("[area]/[controller]/[action]")]
public class MakesController(
    IAppLogger appLogger,
    IMakeDataService makeDataService) : BaseCrudController<Make>(
    appLogger,
    makeDataService)
{
    // GET: Admin/Makes
    [Route("/Admin")]
    [Route("/Admin/[controller]")]
    [Route("/Admin/[controller]/[action]")]
    public override Task<IActionResult> IndexAsync() => base.IndexAsync();
}