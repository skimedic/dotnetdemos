// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/12/03
// ==================================

namespace AutoLot.Api.Controllers;

[ApiController]
[ApiVersionNeutral]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController(
    IAppLogging appLogging) : ControllerBase
{
    [HttpGet("problem")]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Returns a problem response")]
    [EndpointDescription("Returns a NotFound response to demonstrate ProblemDetails handling.")]
    public IActionResult Problem() => NotFound();

    [HttpGet("logging")]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Writes a test log entry")]
    [EndpointDescription("Writes a test error log entry and returns OK.")]
    public IActionResult TestLogging()
    {
        appLogging.LogAppError("Test error");
        return Ok();
    }

    [HttpGet("error")]
    [Produces("application/json")]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    [EndpointSummary("Throws a test exception")]
    [EndpointDescription("Throws a test exception to verify exception handling behavior.")]
    public IActionResult TestExceptionHandling() => throw new Exception("Test Exception");

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet("hidden/{id?}")]
    public string HiddenEndPoint(
        int? id,
        ApiVersion apiVersion) =>
        $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}