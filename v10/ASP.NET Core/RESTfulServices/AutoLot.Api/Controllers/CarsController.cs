// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
//[AdvertiseApiVersions(2.0)]
public class CarsController(
    IAppLogger appLogger,
    ICarRepo carRepo) : BaseCrudController<Car>(
    appLogger,
    carRepo)
{
    [HttpGet("bymake/{makeId?}")]
    [Produces("application/json")]
    [ProducesResponseType<IEnumerable<Car>>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets cars by make ID.")]
    [EndpointDescription(
        "Returns a list of cars filtered by make ID. Example: GET /api/cars/bymake/1. No request body required.")]
    public ActionResult<IEnumerable<Car>> ByMake(
        [Description("The make ID to filter cars. Optional.")]
        int? makeId) =>
        Ok(makeId is > 0 ? carRepo.GetAllByAsList(makeId.Value) : MainRepoInstance.GetAllAsList());

    [ApiVersion(
        1.5,
        Deprecated = true)]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<IEnumerable<Car>>(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Car>> GetAllBad() => throw new Exception("I said not to use this one");
}