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
	[EndpointSummary("Example problem report")]
    [EndpointDescription("An example endpoint that returns a problem report with a 404 status code.")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public IActionResult Problem() => NotFound();

    [HttpGet("logging")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public IActionResult TestLogging()
    {
        appLogging.LogAppError("Test error");
        return Ok();
    }

    [HttpGet("error")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
    public IActionResult TestExceptionHandling() => throw new Exception("Test Exception");

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet("hidden/{id?}")]
    public string HiddenEndPoint(int? id, ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}