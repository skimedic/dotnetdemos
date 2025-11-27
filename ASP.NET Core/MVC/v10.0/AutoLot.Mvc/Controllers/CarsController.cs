// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/27
// ==================================

namespace AutoLot.Mvc.Controllers;

public class CarsController(
    IAppLogging appLogging,
    ICarRepo baseRepo,
    IMakeRepo makeRepo)
    : BaseCrudController<Car>(appLogging, baseRepo)
{
    protected override SelectList GetLookupValues() =>
        new(makeRepo.GetAll().OrderBy(m => m.Name).ToList(), "Id", "Name");

    [HttpGet("{makeId}/{makeName}")]
    public IActionResult ByMake(
        int makeId,
        string makeName)
    {
        ViewBag.MakeName = makeName;
        return View(((ICarRepo)BaseRepoInstance).GetAllBy(makeId));
    }

    // public IActionResult BadEndPoint() => new OkObjectResult(5);
}
