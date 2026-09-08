// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - CarsBetaController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion("2.5-Beta")]
[ApiVersion(
    3.0,
    "Beta")]
public class CarsBetaController(
    IAppLogger appLogger,
    ICarRepo carRepo) : BaseCrudController<Car>(
    appLogger,
    carRepo)
{
    [MapToApiVersion("2.5-Beta")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<IEnumerable<Car>>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets all future cars (Beta 2.5).")]
    [EndpointDescription("Returns all future cars for Beta 2.5. Example: GET /api/carsbeta. No request body required.")]
    public ActionResult<IEnumerable<Car>> GetAllFuture() => throw new NotImplementedException("I'm working on it");

    [MapToApiVersion("3.0-Beta")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType<IEnumerable<Car>>(StatusCodes.Status200OK)]
    [EndpointSummary("Gets all future cars (Beta 3.0).")]
    [EndpointDescription("Returns all future cars for Beta 3.0. Example: GET /api/carsbeta. No request body required.")]
    public ActionResult<IEnumerable<Car>> GetAllFutureBeta() => throw new NotImplementedException("I'm working on it");
}