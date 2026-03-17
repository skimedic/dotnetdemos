// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class CarsController(
    IAppLogging appLogging,
    ICarRepo carRepo)
    : BaseCrudController<Car>(appLogging, carRepo)
{
    [HttpGet("bymake/{makeId?}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets cars by make ID.")]
    [EndpointDescription("Returns a list of cars filtered by make ID. Example: GET /api/cars/bymake/1. No request body required.")]
    public ActionResult<List<Car>> ByMake(
        [Description("The make ID to filter cars. Optional.")] int? makeId)
        => makeId is > 0
            ? Ok(((ICarRepo)MainRepoInstance).GetAllBy(makeId.Value))
            : GetAll();

    [ApiVersion(1.5, Deprecated = true)]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<Car>> GetAllBad() => throw new Exception("I said not to use this one");
}