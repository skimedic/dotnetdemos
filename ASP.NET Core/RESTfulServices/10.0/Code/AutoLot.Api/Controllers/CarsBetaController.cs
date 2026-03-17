// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CarsBetaController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion("2.5-Beta")]
[ApiVersion(3.0,"Beta")]
public class CarsBetaController(
    IAppLogging appLogging,
    ICarRepo carRepo)
    : BaseCrudController<Car>(appLogging, carRepo)
{
    [MapToApiVersion("2.5-Beta")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets all future cars (Beta 2.5).")]
    [EndpointDescription("Returns all future cars for Beta 2.5. Example: GET /api/carsbeta. No request body required.")]
    public ActionResult<IQueryable<Car>> GetAllFuture() => throw new NotImplementedException("I'm working on it");

    [MapToApiVersion("3.0-Beta")]
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Gets all future cars (Beta 3.0).")]
    [EndpointDescription("Returns all future cars for Beta 3.0. Example: GET /api/carsbeta. No request body required.")]
    public ActionResult<IQueryable<Car>> GetAllFutureBeta() => throw new NotImplementedException("I'm working on it");
}