// Copyright Information
// ==================================
// AutoLot-APIs - AutoLot.Api - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2026/09/07
// ==================================

namespace AutoLot.Api.Controllers.Specials;

[ApiVersionNeutral]
public class ValuesController(
    IAppLogger appLogger) : BaseAppController
{
    [HttpGet("problem")]
    [Produces("application/json")]
    [EndpointSummary("Returns a problem response")]
    [EndpointDescription("Returns a NotFound response to demonstrate ProblemDetails handling.")]
    public IActionResult Problem() => NotFound();

    [HttpGet("logging")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [EndpointSummary("Writes a test log entry")]
    [EndpointDescription("Writes a test error log entry and returns OK.")]
    public IActionResult TestLogging()
    {
        appLogger.LogAppError("Test error");
        return Ok();
    }

    [HttpGet("error")]
    [Produces("application/json")]
    [EndpointSummary("Throws a test exception")]
    [EndpointDescription("Throws a test exception to verify exception handling behavior.")]
    public IActionResult TestExceptionHandling() => throw new Exception("Test Exception");

    [ApiExplorerSettings(IgnoreApi = true)]
    [ProducesResponseType<string>(StatusCodes.Status200OK)]
    [HttpGet("hidden/{id?}")]
    public ActionResult<string> HiddenEndPoint(
        int? id,
        ApiVersion apiVersion) =>
        $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}