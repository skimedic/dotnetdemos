// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class MakesController(IAppLogging appLogging, IMakeDataService mainDataService)
    : BaseCrudController<Make>(appLogging, mainDataService)
{
    protected override Task<SelectList> GetLookupValuesAsync() => Task.FromResult<SelectList>(null);

    // GET: Admin/Makes
    [Route("/Admin")]
    [Route("/Admin/[controller]")]
    [Route("/Admin/[controller]/[action]")]
    public override async Task<IActionResult> IndexAsync() => await base.IndexAsync();
}