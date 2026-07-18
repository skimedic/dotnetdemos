// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/07/13
// ==================================

namespace AutoLot.Mvc.Controllers;

public class CarsController(
    IAppLogging appLogging,
    ICarDataService carDataService,
    IMakeDataService makeDataService) : BaseCrudController<Car>(appLogging, carDataService)
{
    protected override async Task<SelectList> GetLookupValuesAsync() =>
        new((await makeDataService.GetAllAsync()).OrderBy(m => m.Name), nameof(Make.Id), nameof(Make.Name));

    [HttpGet("{makeId}/{makeName}")]
    public async Task<IActionResult> ByMakeAsync(
        int makeId,
        string makeName)
    {
        ViewBag.MakeName = makeName;
        return View(await carDataService.GetAllByMakeIdAsync(makeId));
    }
    //public IActionResult BadEndPoint() => new OkObjectResult(5);
}